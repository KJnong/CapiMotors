using System;
using System.Collections.Generic;
using System.Text;
using CapiMotors.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CapiMotors.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Images>()
            .HasKey(c => new { c.VehicleId, c.ImageName });
            base.OnModelCreating(builder);

            builder.Entity<Vehicle>().HasMany(n => n.notifications).WithOne(v => v.Vehicle);
           
        }
    }
}
