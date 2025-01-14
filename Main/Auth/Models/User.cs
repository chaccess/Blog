﻿namespace Main.Auth.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string NickName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Default;
    }
}
