﻿namespace SimpleMapping
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Adress { get; set; }

        public bool isOnVacation { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }
    }
}
