namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class StudentsContext : DbContext
    {

        public StudentsContext()
            : base("name=StudentsContext")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}