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
            var sale = _context.Vehicles.Where(v =>v.Status == StatusType.Published ).ToList();
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
            (!string.IsNullOrEmpty(search.Make) && v.Make == search.Make) && 
            (search.PriceRange.HasValue && v.Price >= priceRange.MinPrice) &&
            (search.PriceRange.HasValue && v.Price <= priceRange.MaxPrice)).ToList();
        }

      
        private (int MinPrice, int MaxPrice) GetPriceRange(PriceRangeSearch price)
        {
            //TODO: Finish the cases
            switch (price)
            {
                case PriceRangeSearch.R10K_R50K:
                    return (10000, 50000);

                case PriceRangeSearch.R50K_R100K:
                    return (50000, 100000);

                case PriceRangeSearch.R100K_R200K:
                    return (100000, 300000);

                case PriceRangeSearch.R200K_R300K:
                    return (200000, 300000);

                case PriceRangeSearch.R300K_R400K:
                    return (300000, 400000);

                case PriceRangeSearch.R400K_R500K:
                    return (400000, 500000);

                case PriceRangeSearch.R500K_R600K:
                    return (500000, 600000);

                case PriceRangeSearch.R600K_R700K:
                    return (600000, 700000);

                case PriceRangeSearch.R700K_R800K:
                    return (700000, 800000);

                case PriceRangeSearch.R800K_R900K:
                    return (800000, 900000);

                case PriceRangeSearch.R900K_R1m:
                    return (900000, 1000000);

                case PriceRangeSearch.R1m_R2m:
                    return (1000000, 2000000);

                default:
                    return (0, 500000000);

            }
        }
    }
}
