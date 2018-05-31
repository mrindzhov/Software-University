namespace UsersDatabase.Models
{
    using Attributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }

        [Required,Tag]
        public string TagLabel { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}
