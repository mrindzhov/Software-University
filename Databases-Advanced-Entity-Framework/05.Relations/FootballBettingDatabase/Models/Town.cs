namespace Models
{
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

    }
}