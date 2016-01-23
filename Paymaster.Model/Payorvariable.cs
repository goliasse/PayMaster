using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class PayorVariable : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Payor Payors { get; set; }
        public virtual int Flag1 { get; set; }
        public virtual int? Value1 { get; set; }
    }
}