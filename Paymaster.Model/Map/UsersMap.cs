using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Paymaster.Model;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps {
    
    
    public class UsersMap : ClassMap<Users> {
        
        public UsersMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Username).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Password).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Locked);
            Map(x => x.Sessionid);
            Map(x => x.Sessionstart);
            Map(x => x.Sessionend);
			//ManyToOne(x => x.Payors, map => { map.Column("payorID"); map.Cascade(Cascade.None); });

        }
    }
}
