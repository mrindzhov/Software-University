
namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            SalesOfProduct= new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Sale> SalesOfProduct { get; set; }
    }
}