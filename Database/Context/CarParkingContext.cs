//CarParkingContext.cs
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class CarParkingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5NMO71P;Database=CarParkingManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-1H8PV8J\SQLEXPRESS01;Database=CarParkingManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;ConnectRetryCount=0");
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Slot> Slot { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Role> Role { get; set; }
    }

}