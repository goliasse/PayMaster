using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class Email : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual int Type { get; set; }
        public virtual int? Isprimary { get; set; }
        public virtual string Name { get; set; }
        public virtual string Domain { get; set; }
        public virtual string Notes { get; set; }
    }
}