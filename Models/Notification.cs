using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Numbers { get; set; }
        public bool Read { get; set; }
    }
}
