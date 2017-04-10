namespace WeddingsPlanner.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WeddingsPlanner.Models.Enums;

    [Table("Gifts")]
    public class Gift : Present
    {
        [Required]
        public string Name { get; set; }

        public Size? Size { get; set; }
    }
}
