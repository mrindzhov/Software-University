using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.companyRoaster
{
    public class Employee
    {
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();
            for (int i = 0; i < people; i++)
            {
                var employeeInfo = Console.ReadLine().Split(' ');
                var employee = new Employee(employeeInfo[0],
                    decimal.Parse(employeeInfo[1]),
                    employeeInfo[2],
                    employeeInfo[3]);
                if (employeeInfo.Length == 5)
                {
                    var ageOrEmail = employeeInfo[4];
                    if (ageOrEmail.Contains('@')) employee.email = ageOrEmail;
                    else employee.age = int.Parse(ageOrEmail);
                }
                if (employeeInfo.Length == 6)
                {
                    var ageOrEmail = employeeInfo[4];
                    if (ageOrEmail.Contains('@')) employee.email = ageOrEmail;
                    else employee.age = int.Parse(ageOrEmail);

                    var ageOrEmail5 = employeeInfo[5];
                    if (ageOrEmail5.Contains('@')) employee.email = ageOrEmail5;
                    else employee.age = int.Parse(ageOrEmail5);
                }
                employees.Add(employee);
            }
            var result = employees.GroupBy(e => e.department)
                .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.salary),
                Employees = e.OrderByDescending(emp => emp.salary)
            })
            .OrderByDescending(dep => dep.AverageSalary)
            .First();
            Console.WriteLine("Highest Average Salary: "+result.Department);
            foreach (var employee in result.Employees)
            {
                Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
            }

        }
    }
}