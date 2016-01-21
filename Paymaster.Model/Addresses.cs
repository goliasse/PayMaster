using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class Addresses : IIsDeletable, IIdAble<int>
    {
        public virtual int Id { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual int Type { get; set; }
        public virtual int Isprimary { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Line3 { get; set; }
        public virtual int? City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Notes { get; set; }
    }
}