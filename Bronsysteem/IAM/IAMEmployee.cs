using System;
using System.Collections.Generic;
using System.Text;

namespace Bronsysteem.IAM
{
    public class IAMEmployee
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddelName { get; set; }
        public IAMEmployee(Guid? guid, string firstName, string lastName, string? middelName)
        {
            Guid = guid ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            MiddelName = middelName;
        }

        public IAMEmployee() {
            FirstName = null!;
            LastName = null!;
            MiddelName = null!;
        }
    }
}
