using CapiMotors.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.ViewModels

{
    public class VehicleFormViewModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        public bool PreviouslyOwned { get; set; }

        [Required]
        public bool TowBar { get; set; }

        [Required]
        public bool SunRoof { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        
    }
}
