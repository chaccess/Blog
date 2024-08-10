using Main.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Auth.Data
{
    public class AuthDBContext : DbContext
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    NickName = "System",
                    Email = "System",
                    Password = "System",
                }
            );
        }
    }
}
