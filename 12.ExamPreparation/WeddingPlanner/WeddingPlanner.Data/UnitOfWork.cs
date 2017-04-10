namespace WeddingsPlanner.Data
{
    using WeddingsPlanner.Data.Repositories;
    using WeddingsPlanner.Data.Interfaces;
    using WeddingsPlanner.Models;
    using System.Data.Entity;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        public UnitOfWork(WeddingsPlannerContext context)
        {
            this.context = context;
            this.Agencies = new AgencyRepository(context);
            this.Invitations = new InvitationRepository(context);
            this.People = new PersonRepository(context);
            this.Venues = new VenueRepository(context);
            this.Presents = new PresentRepository(context);
            this.Weddings = new WeddingRepository(context);
        }
        public UnitOfWork() : this(new WeddingsPlannerContext())
        {
        }
        public IRepository<Agency> Agencies { get; private set; }
        public IRepository<Venue> Venues { get; private set; }
        public IRepository<Person> People { get; private set; }
        public IRepository<Wedding> Weddings { get; private set; }
        public IRepository<Invitation> Invitations { get; private set; }
        public IRepository<Present> Presents { get; private set; }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
