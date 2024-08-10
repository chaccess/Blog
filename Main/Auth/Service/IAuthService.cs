using Main.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Auth.Service
{
    public interface IAuthService
    {
        Task<AuthResponse?> Authenticate(AuthRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(Guid id);
        Task<User?> AddAndUpdateUser(User userObj);
    }
}
