using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class Useraccess : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual int? Userid { get; set; }
        public virtual int? Access { get; set; }
        public virtual int? Permission { get; set; }
    }
}