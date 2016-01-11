using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Paymaster.Model;


namespace Paymaster.Model.Maps {
    
    
    public class EmailsMap : ClassMap<Emails> {
        
        public EmailsMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Type).Not.Nullable(); ;//, map => map.NotNullable(true));
            Map(x => x.Isprimary);
            Map(x => x.Name);
            Map(x => x.Domain);
            Map(x => x.Notes);
			//ManyToOne(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });

        }
    }
}
