using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class User : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Payor Payor { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Locked { get; set; }
        public virtual string SessionId { get; set; }
        public virtual DateTime? SessionStart { get; set; }
        public virtual DateTime? SessionEnd { get; set; }
        public virtual string Roles { get; set; }
    }
}