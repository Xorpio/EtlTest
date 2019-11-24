using System;
using System.Collections.Generic;
using System.Text;

namespace Bronsysteem
{
    public class StudentImport
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddelName { get; set; }
        public string Lessons { get; set; }

        public StudentImport(Guid? guid, string firstName, string lastName, string? middelName, string lessons)
        {
            Guid = guid ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            MiddelName = middelName;
            Lessons = lessons;
        }
        public StudentImport()
        {
            FirstName = null!;
            LastName = null!;
            Lessons = null!;
        }
    }
}
