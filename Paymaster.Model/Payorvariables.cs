using Paymaster.Model.Interfaces;

namespace Paymaster.Model
{
    public class Payorvariables : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Payors Payors { get; set; }
        public virtual int Flag1 { get; set; }
        public virtual int? Value1 { get; set; }
    }
}