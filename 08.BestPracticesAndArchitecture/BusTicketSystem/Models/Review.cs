namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [Range(1, 10)]
        public float Grade { get; set; }

        public int BusCompanyId { get; set; }

        public int CustomerId { get; set; }

        public DateTime? DateOfPublish { get; set; }

        public virtual BusCompany BusCompany { get; set; }

        public virtual Customer Customer { get; set; }
    }
}