namespace TeamBuilder.App.Repositories
{
    using System.Data.Entity;
    using TeamBuilder.App.Contracts;
    using TeamBuilder.Models;

    public class UnitOfWork : IUnitOfWork
    {
        //public UnitOfWork(DbContext dbC)
        //{
        //    this.dbContext = dbC;
        //}
        private readonly DbContext dbContext = new TeamBuilderContext();

        protected DbContext DbContext => dbContext;

        private IRepository<Event> events;

        private IRepository<User> users;

        private IRepository<Team> teams;

        private IRepository<Invitation> invitations;

        public virtual IRepository<Event> Events
        {
            get { return events ?? (this.events = new Repository<Event>(this.dbContext)); }
        }
        public virtual IRepository<User> Users
        {
            get { return users ?? (this.users = new Repository<User>(this.dbContext)); }
        }
        public virtual IRepository<Team> Teams
        {
            get { return teams ?? (this.teams = new Repository<Team>(this.dbContext)); }
        }
        public virtual IRepository<Invitation> Invitations
        {
            get { return invitations ?? (this.invitations = new Repository<Invitation>(this.dbContext)); }
        }

        protected virtual void ConfigureContext(DbContext dbContext)
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}