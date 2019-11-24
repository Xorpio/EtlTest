using System;

namespace Bronsysteem.Events
{
    public class ContractEvent
    {
        public ContractEvent(Guid guid, action action)
        {
            Guid = guid;
            Action = action;
        }

        public ContractEvent() { }

        public Guid Guid { get; set; }
        public action Action { get; set; }
    }
}
