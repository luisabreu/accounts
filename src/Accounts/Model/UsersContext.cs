using Microsoft.Data.Entity;

namespace Accounts.Model {
    public class UsersContext : DbContext {
        public DbSet<UserInfo> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ForSqlServerUseIdentityColumns();

            var userDb = modelBuilder.Entity<UserInfo>();
            userDb.ToTable("Users");

            userDb.HasKey(u => u.IdUserInfo);
            userDb.Property(u => u.Version).IsConcurrencyToken();

            userDb.Property(u => u.GivenName).IsRequired();
            userDb.Property(u => u.Surname).IsRequired();
            userDb.Property(u => u.Department).IsRequired();
            userDb.Property(u => u.Description).IsRequired();
        }
    }
}