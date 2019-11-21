using System;

namespace Bronsysteem
{
    public class Employee
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddelName { get; set; }

        public Employee(Guid? guid, string firstName, string lastName, string? middelName)
        {
            Guid = guid ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            MiddelName = middelName;
        }

        public Employee() {
            FirstName = null!;
            LastName = null!;
            MiddelName = null!;
        }
    }
}
