using System;
using System.Text;
using System.Collections.Generic;


namespace Paymaster.Model {
    
    public class Users {
        public virtual int Id { get; set; }
        public virtual Payors Payors { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual int? Locked { get; set; }
        public virtual string Sessionid { get; set; }
        public virtual DateTime? Sessionstart { get; set; }
        public virtual DateTime? Sessionend { get; set; }
    }
}
