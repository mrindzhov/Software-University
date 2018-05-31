namespace WeddingsPlanner.Models
{
    using System.ComponentModel.DataAnnotations;
    using WeddingsPlanner.Models.Enums;
    public class Invitation
    {
        public int Id { get; set; }

        public int WeddingId { get; set; }

        public int GuestId { get; set; }

        public int PresentId { get; set; }

        public bool IsAttending { get; set; }
        [Required]
        public Family Family { get; set; }

        public virtual Present Present { get; set; }
        [Required]
        public virtual Person Guest { get; set; }
        [Required]
        public virtual Wedding Wedding { get; set; }

    }
}
