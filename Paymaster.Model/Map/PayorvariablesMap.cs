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
    
    
    public class PayorvariablesMap : ClassMap<Payorvariables> {
        
        public PayorvariablesMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Flag1).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Value1);
			//ManyToOne(x => x.Payors, map => { map.Column("payorID"); map.Cascade(Cascade.None); });

        }
    }
}
