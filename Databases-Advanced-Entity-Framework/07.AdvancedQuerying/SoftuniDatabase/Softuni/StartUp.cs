namespace Softuni
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {

            var ctx = new SoftuniContext();

            #region 17.	Call a Stored Procedure
                #region Procedure in MSSQL
                //            create PROCEDURE GetProjectsForEmployee
                //    (@firstName varchar(30), @lastName Varchar(30))
                //As
                //Begin
                //select p.*from Employees as e
                //inner join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID
                //inner join Projects as p on ep.ProjectID = p.ProjectID
                //where e.FirstName = @firstName and e.LastName = @lastName
                //End
                #endregion

            Console.Write("Enter employee first and last name: ");
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            SqlParameter param1 = new SqlParameter("@firstName", names[0]);
            SqlParameter param2 = new SqlParameter("@lastName", names[1]);

            ctx.Database
                .SqlQuery<Project>("exec dbo.GetProjectsForEmployee @firstName, @lastName", param1, param2)
                .Select(p => new
                {
                    p.Name,p.Description,p.StartDate
                })
                .ToList().ForEach(p=>
                {
                    Console.WriteLine($"{p.Name} - {p.Description}, {p.StartDate}");
                });
            
            #endregion

            #region 18.	Employees Maximum Salaries
            //ctx.Departments.Where(d => d.Employee.Salary > 70000 || d.Employee.Salary < 30000)
            //    .ToList().ForEach(d =>
            //    {
            //        Console.WriteLine($"{d.Name} {d.Employees.Max(e=>e.Salary):f2}");
            //    });
            #endregion

        }
    }
}
