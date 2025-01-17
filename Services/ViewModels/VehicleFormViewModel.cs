﻿using CapiMotors.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.ViewModels

{
    public class VehicleFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        public bool PreviouslyOwned { get; set; }

        [Required]
        public bool TowBar { get; set; }

        [Required]
        public bool SunRoof { get; set; }

        [Required]
        public List<IFormFile> OtherImages { get; set; }

        public string Action { get; set; }


        [Required]
        public IFormFile MainImage { get; set; }

        public StatusType Status { get; set; }


    }
}
