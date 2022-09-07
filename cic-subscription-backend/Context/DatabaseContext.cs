using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cic_subscriptions_backend.Models;

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
    }
}

