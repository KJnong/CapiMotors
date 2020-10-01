using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductBySeller(string id)
        {
            return _context.Products.Where(v => v.SellerId == id).ToList();
        }

        public List<Product> GetSellerVehiclesWithNotifications(string id)
        {
            return _context.Products.Include(n => n.Notifications).Where(v => v.SellerId == id).ToList();
            
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(v => v.Id == id).SingleOrDefault();
            ;
        }

        public void AddProduct(Product vehicle)
        {
            _context.Add(vehicle);
        }

        public void RemoveProduct(Product vehicle)
        {
            _context.Remove(vehicle);
        }

        public void Cancel(int id)
        {
            var vehicle = _context.Products.Where(v => v.Id == id).FirstOrDefault();
            vehicle.Status = StatusType.Archived;
        }
    }
}
