using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
