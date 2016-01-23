using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class Check : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual PayPeriod Payperiods { get; set; }
        public virtual int? Employeeid { get; set; }
        public virtual string Amount { get; set; }
        public virtual int? Checknumber { get; set; }
        public virtual DateTime? Checkdate { get; set; }
        public virtual int? Banknumber { get; set; }
        public virtual int? Accountnumber { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Firstname { get; set; }
        public virtual int? Voidflag { get; set; }
    }
}