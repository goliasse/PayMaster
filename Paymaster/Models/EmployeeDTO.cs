using System;

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
        public virtual int? Payfrequency { get; set; }
        public virtual decimal Hourlypayrate { get; set; }
        public virtual int? Dailyrate { get; set; }
        public virtual DateTime? Hiredate { get; set; }
        public virtual int? Earnedincomecredit { get; set; }
        public virtual int? Earnedincomecreditchildren { get; set; }
        public virtual int? Maritalstatus { get; set; }
        public virtual int? Allowances { get; set; }
        public virtual int? Dependents { get; set; }
        public virtual int? Exemptions { get; set; }
        public virtual string Flatfit { get; set; }
        public virtual int? Additionalwitholdingflag { get; set; }
        public virtual string Additionalwitholdingamount { get; set; }
        public virtual DateTime? Birthdate { get; set; }
        public virtual int? Race { get; set; }
        public virtual int? Sex { get; set; }
        public virtual int? Parttime { get; set; }
        public virtual int? Filingstatus { get; set; }
        public virtual string State { get; set; }
        public virtual int? Uscitizen { get; set; }
    }
}