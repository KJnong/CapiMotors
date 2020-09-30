using CapiMotors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.ViewModels
{
    public class VehicleViewModel
    {
        public List<Vehicle> Vehicles{ get; set; }
        public List<Notification> Notifications { get; set; }
        public string Search { get; set; }

    }
}
