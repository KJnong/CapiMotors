using CapiMotors.Models;
using System.Collections.Generic;

namespace CapiMotors.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProductBySeller(string id);
        Product GetProduct(int id);
        void AddProduct(Product vehicle);
        void RemoveProduct(Product vehicle);
        void Cancel(int id);
    }
}