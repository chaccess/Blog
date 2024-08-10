using Main.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Auth.Service
{
    public class AuthResponse
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserRole Role { get; set; }


        public AuthResponse(User user, string token)
        {
            Id = user.Id;
            NickName = user.NickName;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}
