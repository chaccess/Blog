using Main.Auth.Common;
using Main.Auth.Data;
using Main.Auth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Main.Auth.Service
{
    public class AuthService(IOptions<AppSettings> appSettings, AuthDBContext context) : IAuthService
    {
        private readonly IOptions<AppSettings> _appSettings = appSettings;
        private readonly AuthDBContext _context = context;


        public async Task<AuthResponse?> Authenticate(AuthRequest model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.NickName == model.Login && x.Password == model.Password);
            user ??= await _context.Users.SingleOrDefaultAsync(x => x.Email == model.Login && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = await generateJwtToken(user);

            return new AuthResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> AddAndUpdateUser(User userObj)
        {
            bool isSuccess = false;
            if (userObj.Id != new Guid())
            {
                var obj = await _context.Users.FirstOrDefaultAsync(c => c.Id == userObj.Id);
                if (obj != null)
                {
                    // obj.Address = userObj.Address;
                    obj.Email = userObj.Email;
                    obj.NickName = userObj.NickName;
                    _context.Users.Update(obj);
                    isSuccess = await _context.SaveChangesAsync() > 0;
                }
            }
            else
            {
                await _context.Users.AddAsync(userObj);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess ? userObj : null;
        }
        // helper methods
        private async Task<string> generateJwtToken(User user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}