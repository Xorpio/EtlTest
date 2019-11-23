using System;

namespace Bronsysteem
{
    public class EmployeeEvent
    {
        private action add;

        public EmployeeEvent(Guid guid, action add)
        {
            Guid = guid;
            this.add = add;
        }

        public EmployeeEvent() { }

        public Guid Guid { get; set; }
        public action Action { get; set; }
    }
}
