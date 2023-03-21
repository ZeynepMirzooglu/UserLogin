using Microsoft.EntityFrameworkCore;

namespace UserLogin.Models
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options)
           : base(options)
        {

        }
        public DbSet<User> UserLogins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
        }
    }
}
