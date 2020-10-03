using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public List<Vehicle> GetSellerVehiclesWithNotifications(string id)
        {
            var sale = _context.Vehicles.Include(n => n.notifications).Where(v => v.SellerId == id).ToList();
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
            vehicle.Status = StatusType.Archived;

        }

        public List<Vehicle> GetVehiclesBySearchCriteria(SearchDto search)
        {
            var priceRange = GetPriceRange(search.PriceRange.Value);

           return _context.Vehicles.Where(v => 
            (string.IsNullOrEmpty(search.Make) && v.Make == search.Make) && //only include "make" in where clause when its not empty 
            (search.PriceRange.HasValue && v.Price >= priceRange.MinPrice) &&
            (search.PriceRange.HasValue && v.Price <= priceRange.MaxPrice)).ToList();
        }

        //Return type is called a Tuple
        private (int MinPrice, int MaxPrice) GetPriceRange(PriceRangeSearch price)
        {
            //TODO: Finish the cases
            switch (price)
            {
                case PriceRangeSearch.R10K_R50K:
                    return (10000, 50000);

                case PriceRangeSearch.R200K_R300K:
                    return (200000, 300000);

                default:
                    return (10000, 50000);

            }
        }
    }
}
