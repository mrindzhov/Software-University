namespace Models
{
    using System.ComponentModel.DataAnnotations;

    public class CompetitionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
