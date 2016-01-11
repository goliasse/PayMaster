using System;
using System.Text;
using System.Collections.Generic;
using Paymaster.Model.Interfaces;


namespace Paymaster.Model {
    
    public class Payors : IDeletable, IIdAble<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsDeleted { get; set; }
        
    }
}
