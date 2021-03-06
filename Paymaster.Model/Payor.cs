using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class Payor : IIsDeletable, IIdAble<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual bool IsDeleted { get; set; }
    }
}