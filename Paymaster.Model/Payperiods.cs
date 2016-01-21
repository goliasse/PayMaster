using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class Payperiods : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Payors Payors { get; set; }
        public virtual int? Payfrequency { get; set; }
        public virtual DateTime? Enddate { get; set; }
        public virtual DateTime? Startdate { get; set; }
        public virtual DateTime? Checkdate { get; set; }
        public virtual DateTime? Tansferdate { get; set; }
        public virtual int? Status { get; set; }
        public virtual int? Runcount { get; set; }
        public virtual int? Inprogress { get; set; }
    }
}