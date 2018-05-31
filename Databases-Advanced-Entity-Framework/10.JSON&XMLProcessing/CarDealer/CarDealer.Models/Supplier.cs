﻿namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Supplier
    {
        public Supplier()
        {
            this.Parts = new HashSet<Part>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

    }
}