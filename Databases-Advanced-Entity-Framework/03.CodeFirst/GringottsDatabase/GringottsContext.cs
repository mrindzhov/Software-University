namespace GringottsDatabase
{
    using System.Data.Entity;
    using Models;

    public class GringottsContext : DbContext
    {
     
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }

     
        public virtual DbSet<WizardDeposits> Deposits{ get; set; }
    }
}