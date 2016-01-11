using System;
using System.Text;
using System.Collections.Generic;


namespace Paymaster.Model {
    
    public class Employeechangelog {
        public virtual int Id { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual DateTime? Changedate { get; set; }
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual int? Userid { get; set; }
    }
}
