﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string SellerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Numbers { get; set; }
        public bool Read { get; set; }
    }
}
