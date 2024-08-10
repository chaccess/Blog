using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Auth.Service
{
    public class AuthRequest
    {
        [DefaultValue("test")]
        public required string Login { get; set; }

        [DefaultValue("test")]
        public required string Password { get; set; }
    }
}
