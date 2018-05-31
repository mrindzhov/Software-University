namespace _03.CodeFirst_Advanced
{
    using System.Data.Entity;
    using Models;
    public class LocalStoreContext : DbContext
    {
        public LocalStoreContext()
            : base("name=LocalStoreContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LocalStoreContext>());
        }

        public virtual DbSet<Product> Products { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
};