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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
