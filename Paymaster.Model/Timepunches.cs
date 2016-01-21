using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class Timepunches : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual DateTime? Indatetime { get; set; }
        public virtual DateTime? Outdatetime { get; set; }
        public virtual DateTime? Referencedate { get; set; }

        public virtual decimal Hourlypayrate { get; set; }
        public virtual int? Dailyrate { get; set; }

        public virtual string Hours { get; set; }
        public virtual int? Processed { get; set; }
    }
}