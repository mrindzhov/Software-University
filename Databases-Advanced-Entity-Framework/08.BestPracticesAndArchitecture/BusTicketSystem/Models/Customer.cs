namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Customer
    {
        public Customer()
        {
            this.Reviews = new HashSet<Review>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";

        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public int HomeTownId { get; set; }

        public int BankAccountId { get; set; }

        public virtual Town HomeTown { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}