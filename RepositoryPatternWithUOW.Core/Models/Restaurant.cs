﻿using Otlob.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Descriptions { get; set; }
        public decimal Rate { get; set; }
        public string Logo { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal DeliveryDuration { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }





    }
}
