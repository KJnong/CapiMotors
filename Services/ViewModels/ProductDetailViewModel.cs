using CapiMotors.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.ViewModels
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<string> Images { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int VehicleId { get; set; }

        public string SellerId { get; set; }
    }
}
