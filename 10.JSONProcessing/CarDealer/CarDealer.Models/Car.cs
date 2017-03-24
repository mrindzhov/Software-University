﻿namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Car
    {
        public Car()
        {
            this.Parts = new HashSet<Part>();
        }
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
