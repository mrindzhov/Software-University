namespace WeddingsPlanner.Data.Repositories
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;

    class WeddingRepository : Repository<Wedding>
    {
        public WeddingRepository(DbContext context) : base(context)
        {
        }
    }
}
