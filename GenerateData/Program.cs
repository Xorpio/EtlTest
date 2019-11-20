using Bogus;
using Bronsysteem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace GenerateData
{
    class Program
    {
        private static readonly int numStudents = 10;
        private static readonly int numEmployees = 5;

        static void Main(string[] args)
        {
            var employeeFaker = new Faker<Employee>("nl")
                .StrictMode(true)
                .RuleFor(e => e.Guid, f => Guid.NewGuid())
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.MiddelName, f => f.PickRandom("de", "van", "van het", null!))
                .FinishWith((f, p) =>
                {
                    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(p));
                });


            var employees = employeeFaker.Generate(numEmployees);

            var faker = new Faker();

            var contracts = new List<Contract>();

            foreach (var emp in employees)
            {
                decimal fte = 0;
                do
                {
                    var curFte = (faker.Random.Bool()) ?
                        1 - fte : Math.Round(faker.Random.Decimal(), 1);

                    if (fte + curFte > 1) {
                        curFte = 1 - fte;
                    }

                    fte += curFte;

                    contracts.Add(new Faker<Contract>("nl")
                        .StrictMode(true)
                        .RuleFor(c => c.Guid, Guid.NewGuid())
                        .RuleFor(c => c.Location, f => f.PickRandom<Locatie>())
                        .RuleFor(c => c.Function, f => f.Name.JobTitle())
                        .RuleFor(c => c.Fte, curFte)
                        .RuleFor(c => c.EmployeeGuid, emp.Guid)
                        .RuleFor(c => c.StartDate, f => f.Date.Past(1))
                        .RuleFor(c => c.EndDate, GenerateDatetime)
                        .FinishWith((f, p) =>
                        {
                            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(p));
                        }).Generate()
                    ) ;
                    
                } while (fte < 1);
            }

            var students = (new Faker<Student>("nl")
                .StrictMode(true)
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.MiddelName, f => f.PickRandom("de", "van", "van het", null!))
                .RuleFor(s => s.Guid, Guid.NewGuid())
                .RuleFor(s => s.Lessons, GenerateLessonsString)
                .FinishWith((f, p) =>
                {
                    Console.WriteLine(JsonSerializer.Serialize(p));
                })
            ).Generate(numStudents);


            System.IO.File.WriteAllText("students.json", JsonSerializer.Serialize(students));
            System.IO.File.WriteAllText("employees.json", JsonSerializer.Serialize(employees));
            System.IO.File.WriteAllText("contracts.json", JsonSerializer.Serialize(contracts));
        }

        private static string GenerateLessonsString(Faker fake, Student s)
        {

            Func<string> faker = () => fake.PickRandom(
                        "Nederlands",
                        "Frans",
                        "Natuurwetenschappen",
                        "Engels",
                        "Duits",
                        "Geschiedenis",
                        "Aardrijkskunde",
                        "Lichamelijke opvoeding",
                        "Biologie",
                        "Chemie",
                        "Fysica",
                        "Wiskunde"
                    ) + ":" + (fake.PickRandom<Locatie>().ToString());

            var lessons = new List<string>();
            for (int i = 0; i < fake.Random.Int(1,5); i++)
            {
                lessons.Add(faker());
            }

            return string.Join(',', lessons);
        }

        private static DateTime? GenerateDatetime(Faker f, Contract c)
        {
            if (f.Random.Bool(0.2f)) { 
                f.Date.Soon(10);
            }
            return null;
        }
    }
}
