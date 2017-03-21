namespace SimpleMapping
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {

            #region Advanced Mapping
            Console.WriteLine("Advanced Mapping");
            List<Employee> managers = SampleEmployeesSeed();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>();
            });


            Mapper.Map<IEnumerable<Employee>,
                IEnumerable<ManagerDto>>(managers)
                .ToList()
                .ForEach(manager =>
                {
                    Console.WriteLine(manager);

                });
            Console.WriteLine();
            #endregion

            #region Projection
            Console.WriteLine("Projection");
            EmployeesContext context = new EmployeesContext();
            //context.Database.Initialize(true);
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dto => dto.ManagerLastName, opt => opt.MapFrom(src => src.Manager.LastName)));

            context.Employees.Where(emp => emp.BirthDay.Value.Year < 1990).OrderByDescending(emp => emp.Salary)
                .ProjectTo<EmployeeDto>().ToList().ForEach(emp =>
                {
                    string MLN = emp.ManagerLastName != null ? emp.ManagerLastName : "[no manager]";
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Salary} - Manager: {MLN}");
                });
            #endregion

        }

        private static List<Employee> SampleEmployeesSeed()
        {
            var managers = new List<Employee>() {
                new Employee()
                {
                    FirstName = "Steve",
                    LastName = "Jobbsen",
                    BirthDay = new DateTime(1997, 11, 11),
                    Salary = 3000.00m,
                    Adress = "Sofia",
                    isOnVacation = false,
                    Subordinates=new HashSet<Employee>(){
                        new Employee()
                        {
                            FirstName = "Stephen",
                            LastName = "Bjorn",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 4300.00m,
                            Adress = "Germany"
                        },
                        new Employee()
                        {
                            FirstName = "Kirilyc",
                            LastName = "Lefi",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 4400.00m,
                            Adress = "Sofia"
                        }
                    }
                },
                new Employee()
                {
                    FirstName = "Carl",
                    LastName = "Kormac",
                    BirthDay = new DateTime(1997, 11, 11),
                    Salary = 4000.00m,
                    Adress = "Sofia",
                    Subordinates=new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Jurgen",
                            LastName = "Stratus",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 1000.45m,
                            Adress = "Sofia",
                            isOnVacation = false,

                        },
                        new Employee()
                        {
                            FirstName = "Moni",
                            LastName = "Kozinac",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 2030.99m,
                            Adress = "Sofia",
                            isOnVacation = false,

                        },
                        new Employee()
                        {
                            FirstName = "Kopp",
                            LastName = "Spidok",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary =2000.21m,
                            Adress = "Sofia"
                        }
                    }
                }
            };
            return managers;
        }
    }
}