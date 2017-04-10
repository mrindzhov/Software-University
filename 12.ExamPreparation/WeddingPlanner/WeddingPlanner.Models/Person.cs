namespace WeddingsPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WeddingsPlanner.Models.Enums;

    public class Person
    {
        public Person()
        {
            this.Invitations = new HashSet<Invitation>();
            this.Bridegrooms = new HashSet<Wedding>();
            this.Brides = new HashSet<Wedding>();
        }
        public int Id { get; set; }
        [Required, StringLength(60, MinimumLength = 1)]
        public string FirstName { get; set; }

        //1 symbol,, first letter from middle name
        [Required, StringLength(1, MinimumLength = 1)]
        public string MiddleNameInitial { get; set; }
        //atleast 2 symbols
        [Required, MinLength(2)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {MiddleNameInitial}. {LastName}";
        [Required]
        public Gender Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (BirthDate == null) return null;
                var now = DateTime.Now;
                int age = now.Year - ((DateTime)this.BirthDate).Year;

                if (now.Month < ((DateTime)BirthDate).Month ||
                    (now.Month == ((DateTime)BirthDate).Month && now.Day < ((DateTime)BirthDate).Day))
                {
                    age--;
                }

                return age;
            }
        }
        public string PhoneNumber { get; set; }
        //TODO : Regex validation for email
        //•	Email – must be in format {user}@{host} where:
        //o	{user} - can contain only alphanumeric characters, ignoring the casing
        //o { host } - can contain only lowercase latin letters and one dot.
        //          The dot cannot be at the beginning or at the end of the host
        //o   Valid Emails - john99JJ @abv.bg, john @abv.bg, 9john @abvbg.bg, JJ @abv.com
        //o   Invalid Emails - john.99@abv.bg, john-J @abv.bg, john99@.abv.bg, john99 @abvbg., jj<3@a.b.bg.
        [RegularExpression(@"[a-zA-Z0-9]+@[a-z]{1,}.[a-z]{1,}",ErrorMessage ="Invalid email!")]
        public string Email { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        [InverseProperty("Bride")]
        public virtual ICollection<Wedding> Brides { get; set; }
        [InverseProperty("Bridegroom")]
        public virtual ICollection<Wedding> Bridegrooms { get; set; }
    }
}
