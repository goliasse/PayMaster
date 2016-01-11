using Paymaster.Model.Interfaces;

namespace Paymaster.Model
{
    public class Payors : IIsDeletable, IIdAble<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual bool IsDeleted { get; set; }
    }
}