using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class Product
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

        public List<Image> Images { get; set; }

        public StatusType Status { get; set; }

        public List<Notification> Notifications { get; set; }

    }
}
