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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Images>()
            .HasOne(s => s.Vehicle)
            .WithMany(g => g.Images)
            .HasForeignKey(s => s.VehicleId);

            base.OnModelCreating(builder);
        }
    }
}
