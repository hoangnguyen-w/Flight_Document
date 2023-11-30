using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document.Entity
{
    public class FlightManagerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupPermission> GroupPermissions { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public FlightManagerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Hàm này để ép dữ liệu mặc định
            this.SeedRoles(modelBuilder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role()
            {
                RoleId = Guid.NewGuid(),
                RoleName = "Admin"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleId = Guid.NewGuid(),
                RoleName = "Staff"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleId = Guid.NewGuid(),
                RoleName = "Pilot"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleId = Guid.NewGuid(),
                RoleName = "Stewardess"
            });
        }
    }
}
