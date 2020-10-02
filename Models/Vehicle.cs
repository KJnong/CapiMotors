using CapiMotors.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public ApplicationUser Seller { get; set; }

        [Required]
        public string SellerId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Year { get; set; }

        public string Colour { get; set; }

        public bool PreviouslyOwned { get; set; }

        public bool TowBar { get; set; }

        public bool SunRoof { get; set; }

        public bool IsCancelled { get; set; }

        public string MainImageName { get; set; }
        public List<Images> OtherImages { get; set; }

        public StatusType Status { get; set; }

        public List<Notification> notifications { get; set; }

        public void Update(VehicleFormViewModel model)
        {
            Make = model.Make;
            Model = model.Model;
            Price = model.Price;
            Year = model.Year;
            Colour = model.Colour;
            PreviouslyOwned = model.PreviouslyOwned;
            TowBar = TowBar;
            SunRoof = model.SunRoof;

        }

    }
}
