using System;

namespace Paymaster.DataModel
{
    public class Token
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual string AuthToken { get; set; }
        public virtual DateTime IssuedOn { get; set; }
        public virtual DateTime ExpiresOn { get; set; }

        //public virtual User User { get; set; }
    }
}