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
    
    
    public class AddressesMap : ClassMap<Addresses> {
        
        public AddressesMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Type).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Isprimary).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Line1);
            Map(x => x.Line2);
            Map(x => x.Line3);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.Zip);
            Map(x => x.Notes);
			//ManyToOne(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });

        }
    }
}
