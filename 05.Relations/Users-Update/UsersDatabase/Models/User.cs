namespace UsersDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Attributes;
    using System.Collections.Generic;

    public partial class User
    {
        public User()
        {
            Friends = new HashSet<User>();
            Albums = new HashSet<Album>();
        }

        [Key, Column]
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, Password(4, 20, ShouldContainLowercase = true, ShouldContainUppercase = true, ShouldContainSpecialSymbol = true, ShouldContainDigit = false)]
        public string Password { get; set; }

        [Required, Email]
        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
