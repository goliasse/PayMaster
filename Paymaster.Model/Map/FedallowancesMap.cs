using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Paymaster.Model;


namespace Paymaster.Model.Maps {
    
    
    public class FedallowancesMap : ClassMap<Fedallowances> {
        
        public FedallowancesMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Year).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Payfrequency).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Eachallowanceamount).Not.Nullable();//, map => map.NotNullable(true));
        }
    }
}
