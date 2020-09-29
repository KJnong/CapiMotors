using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Vehicle> GetAllVehicles()
        {
            var sale = _context.Vehicles.ToList();
            return sale;
        }

        public List<Vehicle> GetSellerVehicles(string id)
        {
            var sale = _context.Vehicles.Where(v => v.SellerId == id).ToList();
            return sale;
        }

        public Vehicle GetVehicle(int id)
        {
            var vehicle = _context.Vehicles.Where(v => v.Id == id).SingleOrDefault();
            return vehicle;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Add(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            _context.Remove(vehicle);
        }

        public void Cancel(int id)
        {
            var vehicle = _context.Vehicles.Where(v => v.Id == id).FirstOrDefault();
            vehicle.IsCancelled = false;

        }
    }
}
