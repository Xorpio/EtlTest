using System;

namespace Bronsysteem
{
    public class EmployeeEvent
    {
        public EmployeeEvent(Guid guid, action action)
        {
            Guid = guid;
            Action = action;
        }

        public EmployeeEvent() { }

        public Guid Guid { get; set; }
        public action Action { get; set; }
    }
}
