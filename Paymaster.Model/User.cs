using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class User : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Payor Payors { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Locked { get; set; }
        public virtual string Sessionid { get; set; }
        public virtual DateTime? Sessionstart { get; set; }
        public virtual DateTime? Sessionend { get; set; }
    }
}