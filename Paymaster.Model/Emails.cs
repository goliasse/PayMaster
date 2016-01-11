using System;
using System.Text;
using System.Collections.Generic;


namespace Paymaster.Model {
    
    public class Emails {
        public virtual int Id { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual int Type { get; set; }
        public virtual int? Isprimary { get; set; }
        public virtual string Name { get; set; }
        public virtual string Domain { get; set; }
        public virtual string Notes { get; set; }
    }
}
