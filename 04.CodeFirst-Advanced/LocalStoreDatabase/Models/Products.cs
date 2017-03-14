
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public string DistributorName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public double Weight { get; set; }
        public double Quantity { get; set; }

    }
}
