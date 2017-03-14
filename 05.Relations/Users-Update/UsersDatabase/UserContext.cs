namespace UsersDatabase
{
    using System.Data.Entity;
    using Models;
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UserContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<UsersContext>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

    }
}