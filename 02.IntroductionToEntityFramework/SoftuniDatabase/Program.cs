using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniDatabaseNew
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftuniContext();
            StringBuilder content = new StringBuilder();
            #region //Employees full information       
            //IEnumerable<Employee> employees = context.Employees;
            //foreach (Employee employee in employees)
            //{
            //    content.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            //}
            #endregion
            #region //Employees with Salary Over 50 000    
            //var employees = context.Employees.Where(x => x.Salary > 50000).Select(e => e.FirstName);
            //foreach (string employee in employees)
            //{
            //    content.AppendLine($"{employee}");
            //}
            #endregion
            #region//Employees from Seattle                
            //var employees = context.Employees
            //.Where(e=>e.Department.Name=="Research and Development")
            //.OrderBy(e=>e.Salary).ThenByDescending(e=>e.FirstName);
            //foreach (var employee in employees)
            //{
            //    content.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            //}
            #endregion
            #region//Adding a New Address and Updating Employee     
            //var adress = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};
            //var employee = context.Employees
            //.First(e => e.LastName == "Nakov");
            //employee.Address = adress;
            //context.SaveChanges();

            //var employeeAddresses = context.Employees
            //    .OrderByDescending(e => e.Address.AddressID)
            //    .Take(10)
            //    .Select(e => e.Address.AddressText);

            //foreach (string employeeAddress in employeeAddresses)
            //{
            //    content.AppendLine(employeeAddress);
            //}
            #endregion
            #region//Find Employees in Period    
            //var employees = context.Employees
            //.Where(emp => emp.Projects
            //    .Count(p =>
            //        p.StartDate.Year >= 2001 &&
            //        p.StartDate.Year <= 2003) > 0)
            //        .Take(30);

            //foreach (var employee in employees)
            //{
            //    content.AppendLine($"{employee.FirstName} {employee.LastName}" +
            //    $" {employee.Manager.FirstName}");
            //    foreach (Project project in employee.Projects)
            //    {
            //        content.AppendLine($"--{project.Name} {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}" +
            //        $" {project.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            //    }
            //}
            #endregion
            #region//Adresses By Town Name
            //var adresses = context.Addresses
            //        .OrderByDescending(adress => adress.Employees.Count)
            //        .ThenBy(adress => adress.Town.Name)
            //        .Take(10);
            //foreach (var adress in adresses)
            //{
            //    content.AppendLine($"{adress.AddressText}, {adress.Town.Name} - {adress.Employees.Count} employees");
            //}
            #endregion
            #region//Employee with id 147
            //var employee147 = context.Employees.Find(147);
            //content.AppendLine($"{employee147.FirstName} {employee147.LastName}"+ 
            //                $" {employee147.JobTitle}");
            //foreach (var project in employee147.Projects.OrderBy(p=>p.Name))
            //{
            //    content.AppendLine(project.Name);
            //}
            #endregion
            #region//Departments with more than 5 employees
            //var departments = context.Departments
            //.Where(d => d.Employees.Count > 5)
            //.OrderBy(d=>d.Employees.Count);
            //foreach (var dep in departments)
            //{
            //    content.AppendLine($"{dep.Name} {dep.Employee.FirstName}");

            //    foreach (var empl in dep.Employees)
            //    {
            //        content.AppendLine($"{empl.FirstName} {empl.LastName} {empl.JobTitle}");
            //    }
            //}
            #endregion
            #region//Find Latest 10 Projects
            //var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10);
            //foreach (var proj in projects.OrderBy(p => p.Name))
            //{
            //    content.AppendLine($"{proj.Name} {proj.Description}"+
            //    $" {proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            //}
            #endregion
            #region//Increase Salaries
            //var employees = context.Employees.Where(e => e.Department.Name == "Engineering"
            //      || e.Department.Name == "Tool Design"
            //      || e.Department.Name == "Marketing"
            //      || e.Department.Name == "Information Services");

            //foreach (var empl in employees)
            //{
            //    empl.Salary *= 1.12m;
            //    content.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary})");
            //}
            //context.SaveChanges();
            #endregion
            #region//Find Employees by First Name Starting with "SA"
            //var employees = context.Employees.Where(e => e.FirstName.StartsWith("SA"));
            //foreach (var empl in employees)
            //{
            //    content.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary})");
            //}
            #endregion
            #region//Delete Project by ID =2
            //var projectToDelete = context.Projects.Find(2);
            //var employees = context.Employees;
            //foreach (var empl in employees)
            //{
            //    empl.Projects.Remove(projectToDelete);
            //}
            //context.SaveChanges();

            //var projects = context.Projects.Take(10).Select(project1 => project1.Name);

            //foreach (var proj in projects)
            //{
            //    content.AppendLine(proj);
            //}
            #endregion
            #region//Remove Towns with name as an input
            //Console.Write("Enter town to delete: ");
            //string townName = Console.ReadLine();

            //var townToDelete = context.Towns.FirstOrDefault(n => n.Name.Equals(townName));
            //int count = 0;
            //foreach (var adress in townToDelete.Addresses.ToArray())
            //{

            //    foreach (var employee in adress.Employees.ToArray())
            //    {
            //        employee.Address = null;
            //    }
            //    context.Addresses.Remove(adress);
            //    count++;
            //}

            //context.Towns.Remove(townToDelete);
            //context.SaveChanges();
            //int counterCopy = townToDelete.Addresses.ToArray().Length;
            //if (count != 0)
            //{
            //    if (count == 1)
            //    {
            //        content.AppendLine($"{count} adress in {townToDelete.Name} was deleted");
            //    }
            //    else
            //    {
            //        content.AppendLine($"{count} adresses in {townToDelete.Name} were deleted");

            //    }
            //}
            #endregion
            #region//Native SQL Query    
            context.Addresses.Count();

            var timer = new Stopwatch();

            timer.Start();
            PrintNameWithLinq(context);
            timer.Stop();
            content.AppendLine($"Linq: {timer.Elapsed}");
            timer.Reset();


            timer.Start();
            PrintNamesWithNativeQuery(context);
            timer.Stop();
            content.AppendLine($"Native: {timer.Elapsed}");
            timer.Reset();
            #endregion



            Console.WriteLine(content);

        }
        private static void PrintNameWithLinq(SoftuniContext context)
        {
            var employeesNames =
                context.Employees
                    .Where(employee =>
                        employee.Projects.Count(project => project.StartDate.Year == 2002) != 0)
                    .Select(employee => employee.FirstName).GroupBy(s => s);
            foreach (var s in employeesNames)
            {

            }
        }

        private static void PrintNamesWithNativeQuery(SoftuniContext context)
        {
            string query = "SELECT em.FirstName FROM Employees em " +
                           "JOIN EmployeesProjects emproj " +
                           "ON emproj.EmployeeId = em.EmployeeId " +
                           "JOIN Projects proj " +
                           "ON emproj.ProjectId = proj.ProjectId AND YEAR(proj.StartDate) = 2002 " +
                           "GROUP BY em.FirstName";
            var result = context.Database.SqlQuery<string>(query);
            foreach (var f in result)
            {

            }

        }
    }
}