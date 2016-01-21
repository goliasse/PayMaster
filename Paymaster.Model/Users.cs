using Paymaster.DataModel;
using Paymaster.Model.Interfaces;
using System;

namespace Paymaster.DataModel
{
    public class Users : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Payors Payors { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Locked { get; set; }
        public virtual string Sessionid { get; set; }
        public virtual DateTime? Sessionstart { get; set; }
        public virtual DateTime? Sessionend { get; set; }
    }
}