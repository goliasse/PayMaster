using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paymaster.Models
{
    public class EmployeeDTO
    {
        public virtual int Id { get; set; }
        public virtual int PayorId { get; set; }
        public virtual int? Number { get; set; }
        //public virtual bool Active { get; set; }
        public virtual string Socsec { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Middlename { get; set; }
    }
}