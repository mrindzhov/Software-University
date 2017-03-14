namespace StoreDatabase
{
    using System.Data.Entity;
    using Models;
    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=Sale")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SalesContext>());
          // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
        } 

        public virtual DbSet<Sale> Sales{ get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<Customer> Customers{ get; set; }
        public virtual DbSet<StoreLocation> StoreLocations{ get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}