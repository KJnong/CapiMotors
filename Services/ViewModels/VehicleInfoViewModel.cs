using CapiMotors.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.ViewModels
{
    public class VehicleInfoViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<string> ImagesNames { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
