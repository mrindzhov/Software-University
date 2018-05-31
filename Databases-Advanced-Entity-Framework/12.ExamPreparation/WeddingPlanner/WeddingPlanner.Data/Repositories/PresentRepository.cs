namespace WeddingsPlanner.Data.Repositories
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;

    class PresentRepository : Repository<Present>
    {
        public PresentRepository(DbContext context) : base(context)
        {
        }
    }
}
