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
        [DefaultValue("System")]
        public required string Login { get; set; }

        [DefaultValue("System")]
        public required string Password { get; set; }
    }
}
