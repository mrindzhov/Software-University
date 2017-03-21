namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            EmployeesContext context = new EmployeesContext();
            Stopwatch stopwatch = new Stopwatch();
            long timePassed = 0L;
            int testCount = 10; // Amount of tests to perform
            for (int i = 0; i < testCount; i++)
            {
                // Clear all query cache
                context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
                stopwatch.Start();

                #region Basic queries -uncomment to use

                #region Lazy
                //QueryWithLazyLoading(context);
                //00:00:00.3050000
                //00:00:00.2740000
                //00:00:00.2660000
                //00:00:00.2890000
                #endregion

                #region Lazy+Selection
                //QueryWithLazyLoadingUsingSelection(context);
                //00:00:00.0600000
                //00:00:00.0660000
                #endregion

                #region Eager+Selection
                //QueryWithEagerLoadingUsinSelection(context);
                //00:00:00.0600000
                //00:00:00.0520000
                #endregion

                #region Eager
                //QueryWithEagerLoading(context);
                //00:00:00.2410000
                //00:00:00.2500000
                //00:00:00.2430000
                //00:00:00.2230000
                #endregion
                #endregion

                #region Query to optimize 
                //var employees = context.Employees
                //          .ToList()
                //          .Where(e => e.Subordinates
                //                    .Any(s => s.Address.Town.Name.StartsWith("B")))
                //          .Distinct();

                //foreach (Employee e in employees)
                //{
                //    string result = $"{e.FirstName}";
                //}
                //00:00:01.6020000 -time
                #endregion

                #region Optimized query
                context.Employees.Include("Address")
                  .Where(e => e.Subordinates
                                .Any(s => s.Address.Town.Name.StartsWith("B")))
                  .Select(e => new
                  {
                      Name = e.FirstName
                  })
                  .Distinct()
                  .ToList()
                  .ForEach(e =>
                  {
                      string result = $"{e.Name}";
                  });
                //00:00:00.0240000
                #endregion

                stopwatch.Stop();
                timePassed += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TimeSpan averageTimePassed = TimeSpan.FromMilliseconds(timePassed / (double)testCount);
            Console.WriteLine(averageTimePassed);

        }
        private static void QueryWithEagerLoadingUsinSelection(EmployeesContext context)
        {
            context.Employees.Include("Department")
                .Include("Address").Select(e => new
                {
                    Name = e.FirstName,
                    DepartmentName = e.Department.Name,
                    Adress = e.Address.AddressText
                }).ToList().ForEach(e =>
                {
                    string result = $"{e.Name} - {e.DepartmentName} - {e.Adress}";
                });
        }

        private static void QueryWithLazyLoadingUsingSelection(EmployeesContext context)
        {
            context.Employees.Select(e => new
            {
                Name = e.FirstName,
                DepartmentName = e.Department.Name,
                Adress = e.Address.AddressText
            }).ToList().ForEach(e =>
            {
                string result = $"{e.Name} - {e.DepartmentName} - {e.Adress}";
            });
        }

        private static void QueryWithEagerLoading(EmployeesContext context)
        {
            context.Employees.Include("Department")
                .Include("Address").ToList().ForEach(e =>
                {
                    string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
                });
        }

        private static void QueryWithLazyLoading(EmployeesContext context)
        {
            context.Employees.ToList().ForEach(e =>
                {
                    string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
                });
        }
    }
}