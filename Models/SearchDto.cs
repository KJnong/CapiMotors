using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class SearchDto
    {
        public string Make { get; set; }
        public PriceRangeSearch? PriceRange { get; set; }

    }
}
