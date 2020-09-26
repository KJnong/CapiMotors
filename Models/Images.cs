using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class Images
    {
        public int Id { get; set; }

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }

        public string ImageName { get; set; }
    }
}


