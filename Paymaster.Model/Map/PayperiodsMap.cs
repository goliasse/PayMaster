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
    
    
    public class PayperiodsMap : ClassMap<Payperiods> {
        
        public PayperiodsMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Payfrequency);
            Map(x => x.Enddate);
            Map(x => x.Startdate);
            Map(x => x.Checkdate);
            Map(x => x.Tansferdate);
            Map(x => x.Status);
            Map(x => x.Runcount);
            Map(x => x.Inprogress);
			//ManyToOne(x => x.Payors, map => 
			//{
			//	map.Column("payorID");
			//	map.NotNullable(true);
			//	map.Cascade(Cascade.None);
			//});

        }
    }
}
