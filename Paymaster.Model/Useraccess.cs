using System;
using System.Text;
using System.Collections.Generic;


namespace Paymaster.Model {
    
    public class Useraccess {
        public virtual int Id { get; set; }
        public virtual int? Userid { get; set; }
        public virtual int? Access { get; set; }
        public virtual int? Permission { get; set; }
    }
}
