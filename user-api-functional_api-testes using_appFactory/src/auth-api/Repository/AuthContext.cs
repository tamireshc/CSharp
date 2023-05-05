using Microsoft.EntityFrameworkCore;
using auth_api.Models;

namespace auth_api.Repository
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }
        public AuthContext() { }

        public virtual DbSet<User>? Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");


                optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=user;User=SA;Password=Password12!;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(x => x.UserId);
        }

    }
}
