using System;
using System.Collections.Generic;
using System.Text;

namespace Bronsysteem
{
    public class Contract
    {
        public Contract(Guid? guid, Guid employeeGuid, decimal fte, string function, Locatie location, DateTime startDate, DateTime? endDate)
        {
            Guid = guid ?? Guid.NewGuid();
            EmployeeGuid = employeeGuid;
            Fte = fte;
            Function = function;
            Location = location;
            StartDate = startDate;
            EndDate = EndDate;
        }

        public Contract()
        {
            Function = null!;
        }

        public Guid Guid { get; set; }
        public Guid EmployeeGuid { get; set; }
        public decimal Fte { get; set; }
        public string Function { get; set; }
        public Locatie Location{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
