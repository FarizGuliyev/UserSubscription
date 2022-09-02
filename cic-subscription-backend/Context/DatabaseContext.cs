using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cic_subscriptions_backend.Models;

namespace cic_subscriptions_backend.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {

        }

        public DbSet<User> userContext => Set<User>();
    }
}

