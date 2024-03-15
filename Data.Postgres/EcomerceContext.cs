using Domain.Entities;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Postgres
{
    public class EcomerceContext : IdentityDbContext<IdentityUser>
    {
        public EcomerceContext(DbContextOptions<EcomerceContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Notification>();
            DefaultRoles(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }

        private static void DefaultRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Administrator", ConcurrencyStamp = "eba79445-099f-4167-9f5a-c6b525f7af4c", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Customer", ConcurrencyStamp = "85b69ea8-048c-4d54-998c-8c88ee9f9c9e", NormalizedName = "Customer" },
                new IdentityRole() { Name = "Manager", ConcurrencyStamp = "dfa0a43c-2b47-492d-b23f-461f74c58559", NormalizedName = "Manager" }
                );
        }
    }
}
