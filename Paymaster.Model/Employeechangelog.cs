using System;

namespace Paymaster.DataModel
{
    public class EmployeeChangeLog
    {
        public virtual int Id { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual DateTime? Changedate { get; set; }
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual int? Userid { get; set; }
    }
}