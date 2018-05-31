namespace WeddingsPlanner.Data.Repositories
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;

    class PersonRepository : Repository<Person>
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
