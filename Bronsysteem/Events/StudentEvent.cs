using System;

namespace Bronsysteem.Events
{
    public class StudentEvent
    {
        public StudentEvent(Guid guid, action action)
        {
            Guid = guid;
            Action = action;
        }

        public StudentEvent() { }

        public Guid Guid { get; set; }
        public action Action { get; set; }
    }
}
