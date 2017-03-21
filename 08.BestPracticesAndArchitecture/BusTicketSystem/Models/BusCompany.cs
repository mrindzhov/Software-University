namespace Models
{
    using System.Collections.Generic;

    public class BusCompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}
