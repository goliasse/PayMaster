using System;
using System.Text;
using System.Collections.Generic;


namespace Paymaster.Model {
    
    public class Payorvariables {
        public virtual int Id { get; set; }
        public virtual Payors Payors { get; set; }
        public virtual int Flag1 { get; set; }
        public virtual int? Value1 { get; set; }
    }
}
