namespace WeddingsPlanner.Data.Repositories
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;

    class InvitationRepository : Repository<Invitation>
    {
        public InvitationRepository(DbContext context) : base(context)
        {
        }
    }
}
