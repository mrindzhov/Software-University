using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Course
    {
        //•	Courses: id, name, description (optional), start date, end date, price
        public Course()
        {
            Students = new HashSet<Student>();
            Resources= new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

    }
}