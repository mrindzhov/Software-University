namespace ImportJSON
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ImportJSON.Dtos;
    using ImportJSON.Utilities;
    using Newtonsoft.Json;
    using WeddingsPlanner.Data;
    using WeddingsPlanner.Models;

    class Startup
    {
        static void Main(string[] args)
        {
            ImportData(new UnitOfWork());
        }

        private static void ImportData(UnitOfWork uow)
        {
            ImportAgencies(uow);
            ImportPeople(uow);
            ImportWeddingsAndInvitations(uow);
        }

        private static void ImportWeddingsAndInvitations(UnitOfWork uow)
        {
            var json = File.ReadAllText(@"../../../Imports/weddings.json");
            var weddingsJson = JsonConvert.DeserializeObject<IEnumerable<WeddingDto>>(json);

            foreach (var wedd in weddingsJson)
            {
                var agency = uow.Agencies.Find(a => a.Name == wedd.Agency).FirstOrDefault();
                if (agency == null || wedd.Date == default(DateTime))
                {
                    Printer.PrintError();
                    continue;
                }
                var bride = uow.People.Find(p => p.FirstName + " " + p.MiddleNameInitial + " " + p.LastName == wedd.Bride).FirstOrDefault();
                var bridegroom = uow.People.Find(p => p.FirstName + " " + p.MiddleNameInitial + " " + p.LastName == wedd.Bridegroom).FirstOrDefault();
                var wedding = new Wedding
                {
                    Agency = agency,
                    Bride = bride,
                    BridegRoom = bridegroom,
                    Date = wedd.Date
                };
                if (wedd.Guests != null)
                {
                    foreach (var g in wedd.Guests)
                    {
                        var guest = uow.People.Find(p => p.FirstName + " " + p.MiddleNameInitial + " " + p.LastName == g.Name).FirstOrDefault();
                        if (guest != null)
                        {
                            wedding.Invitations.Add(new Invitation
                            {
                                Guest = guest,
                                IsAttending = g.RSVP,
                                Family = g.Family
                            });
                        }
                    }
                }
                try
                {
                    uow.Weddings.Add(wedding);
                    uow.Commit();
                    Printer.PrintSuccessWedding(bride.FirstName, bridegroom.FirstName);
                }
                catch (Exception)
                {
                    uow.Weddings.Remove(wedding);
                    Printer.PrintError();
                }
            }
        }

        private static void ImportPeople(UnitOfWork uow)
        {
            var json = File.ReadAllText(@"../../../Imports/people.json");
            var peopleJson = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
            var people = new HashSet<Person>();
            {
                foreach (var p in peopleJson)
                {
                    if (p.FirstName == null || p.LastName == null ||
                           p.MiddleInitial == null || p.MiddleInitial.Length != 1)
                    {
                        Printer.PrintError();
                        continue;
                    }
                    var person = new Person()
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        MiddleNameInitial = p.MiddleInitial[0].ToString(),
                        Gender = p.Gender,
                        BirthDate = p.Birthday,
                        PhoneNumber = p.Phone,
                        Email = p.Email
                    };
                    try
                    {
                        uow.People.Add(person);
                        uow.Commit();
                        Printer.PrintSuccess(person.FullName);
                    }
                    catch (Exception)
                    {
                        uow.People.Remove(person);
                        Printer.PrintError();
                    }
                }
            }
        }

        private static void ImportAgencies(UnitOfWork uow)
        {
            var json = File.ReadAllText(@"../../../Imports/agencies.json");
            var agenciesJson = JsonConvert.DeserializeObject<IEnumerable<Agency>>(json);
            foreach (var agency in agenciesJson)
            {
                if (agency.Name != null
                    && agency.EmployeesCount != 0
                    && agency.Town != string.Empty)
                {
                    try
                    {
                        uow.Agencies.Add(agency);
                        uow.Commit();
                        Printer.PrintSuccess(agency.Name);
                    }
                    catch (Exception)
                    {
                        uow.Agencies.Remove(agency);
                        Printer.PrintError();
                    }
                }
                else
                {
                    Printer.PrintError();
                }
            }

        }
    }
}