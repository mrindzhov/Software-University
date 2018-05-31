namespace WeddingsPlanner.Data.Repositories
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;

    class VenueRepository : Repository<Venue>
    {
        public VenueRepository(DbContext context) : base(context)
        {
        }
    }
}
