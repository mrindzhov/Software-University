namespace HospitalDatabase
{
    using Models;
    using System;
    using System.Data.Entity.Validation;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                HospitalContext context = new HospitalContext();
                context.Database.Initialize(true);
                context.Patients.Add(new Patient
                {
                    FirstName = "Kiro",
                    Lastname = "Kirta",
                    Email = "kiro@kiro.kirobg",
                    Address = "kiroStreet5",
                    DateOfBirth = new DateTime(2001,01,01)
                });
                context.Doctors.Add(new Doctor
                {
                    Name = "Doc",
                    Specialty = "Special"
                });
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
        }
    }
}
