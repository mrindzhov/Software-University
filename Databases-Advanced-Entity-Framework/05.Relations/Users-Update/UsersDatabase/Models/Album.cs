namespace UsersDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Album
    {
        public Album()
        {
            Pictures = new HashSet<Picture>();
            Tags = new HashSet<Tag>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<User> Users { get; set; }
        

    }
}