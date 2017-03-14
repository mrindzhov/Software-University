using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            SalesInStore = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
        public ICollection<Sale> SalesInStore { get; set; }
    }
}