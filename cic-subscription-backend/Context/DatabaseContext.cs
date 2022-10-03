using Microsoft.EntityFrameworkCore;
using cic_subscriptions_backend.Models;
using cic_subscription_backend.Models;
using cic_subscription_backend.Models.LocationModels;
using cic_subscription_backend.Models.LocationModels.House;
using cic_subscription_backend.Models.LocationModels.Building;

namespace cic_subscriptions_backend.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Debt).HasPrecision(4, 2);
            modelBuilder.Entity<Payment>().Property(x => x.Amount).HasPrecision(4, 2);
            modelBuilder.Entity<SubscriptionType>().Property(x => x.Price).HasPrecision(4, 2);

            base.OnModelCreating(modelBuilder);
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> User => Set<User>();
        public DbSet<Payment> Payment => Set<Payment>();

        public DbSet<PhoneNumber> PhoneNumber => Set<PhoneNumber>();

        public DbSet<SubscriptionType> SubscriptionType => Set<SubscriptionType>();
        public DbSet<Region> Region => Set<Region>();
        public DbSet<City> City => Set<City>();
        public DbSet<Village> Village => Set<Village>();
        public DbSet<Street> Street => Set<Street>();
        public DbSet<HouseAddress> HouseAddress => Set<HouseAddress>();
        public DbSet<Apartment> Apartment => Set<Apartment>();
        public DbSet<Floor> Floor => Set<Floor>();
        public DbSet<Flat> Flat => Set<Flat>();
    }
}

