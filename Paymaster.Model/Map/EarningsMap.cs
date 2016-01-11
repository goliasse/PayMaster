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
    
    
    public class EarningsMap : ClassMap<Earnings> {
        
        public EarningsMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id).Not.Nullable();//, map => map.Generator(Generators.Assigned));
            Map(x => x.Employeeid);
            Map(x => x.Referencedate);
            Map(x => x.Hours);
            Map(x => x.Hourlypayrate);
            Map(x => x.Overtimemultiplier);
            Map(x => x.Amount);
            Map(x => x.Holiday);
            Map(x => x.Closedflag);
            Map(x => x.Fromtimepunches);
            Map(x => x.Payperiodid);
			//ManyToOne(x => x.Checks, map => 
			//{
			//	map.Column("checkID");
			//	map.NotNullable(true);
			//	map.Cascade(Cascade.None);
			//});

        }
    }
}
