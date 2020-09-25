﻿using System;
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

        [Required]
        public int VehicleId { get; set; }

        public string ImageName { get; set; }
    }
}


