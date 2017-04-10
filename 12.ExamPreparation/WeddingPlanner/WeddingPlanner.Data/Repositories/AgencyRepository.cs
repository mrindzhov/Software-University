namespace WeddingsPlanner.Data.Repositories
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;
    class AgencyRepository : Repository<Agency>
    {
        public AgencyRepository(DbContext context) : base(context)
        {
        }
    }
}
