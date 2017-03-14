namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankSystemContext : DbContext
    {
       public BankSystemContext()
            : base("name=BankSystemContext")
        {
        }
        
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}