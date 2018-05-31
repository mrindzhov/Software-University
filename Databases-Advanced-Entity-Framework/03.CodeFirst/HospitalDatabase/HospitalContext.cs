namespace HospitalDatabase
{
    using System.Data.Entity;
    using Models;
    using Migrations;
    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
            Database.SetInitializer(new Configuration());
        }

        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
    }
}