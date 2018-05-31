namespace WeddingsPlanner.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Present
    {
        public int Id { get; set; }
        [NotMapped]
        public Person Owner { get { return this.Invitation.Guest; } }

        public int InvitationId { get; set; }

        public virtual Invitation Invitation { get; set; }
    }
}