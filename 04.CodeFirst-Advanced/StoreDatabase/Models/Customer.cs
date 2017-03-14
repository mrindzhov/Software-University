
namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            SalesForCustomer = new HashSet<Sale>();

        }
        [Key]
        public int Id { get; set; }
    
        public int Age { get; set; }
        //public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public virtual ICollection<Sale> SalesForCustomer { get; set; }

    }
}
