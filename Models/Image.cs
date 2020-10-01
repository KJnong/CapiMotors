using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Path { get; set; }

        public bool Default { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}


