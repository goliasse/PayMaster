using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class Earning : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Check Checks { get; set; }
        public virtual int? Employeeid { get; set; }
        public virtual DateTime? Referencedate { get; set; }
        public virtual string Hours { get; set; }
        public virtual string Hourlypayrate { get; set; }
        public virtual string Overtimemultiplier { get; set; }
        public virtual string Amount { get; set; }
        public virtual int? Holiday { get; set; }
        public virtual int? Closedflag { get; set; }
        public virtual int? Fromtimepunches { get; set; }
        public virtual int? Payperiodid { get; set; }
    }
}