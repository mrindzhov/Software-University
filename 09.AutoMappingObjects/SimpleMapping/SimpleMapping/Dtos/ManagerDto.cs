namespace SimpleMapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Subordinates = new HashSet<Employee>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }

        public int SubordinatesCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName} | Employees: {SubordinatesCount}");
            foreach (var employee in Subordinates)
            {
                sb.AppendLine($"    - {employee.FirstName} {employee.LastName} {employee.Salary:F2}");
            }

            return sb.ToString().Trim(); 
        }
    }
}
