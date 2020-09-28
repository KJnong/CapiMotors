using CapiMotors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.ViewModels
{
    public class VehicleViewModel
    {
        public List<Vehicle> vehicles{ get; set; }
        public string ImageName { get; set; }
    }
}
