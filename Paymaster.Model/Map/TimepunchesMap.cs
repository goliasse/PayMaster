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
    
    
    public class TimepunchesMap : ClassMap<Timepunches> {
        
        public TimepunchesMap() {
            //Table("Timepunches");
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Indatetime);
            Map(x => x.Outdatetime);
            Map(x => x.Referencedate);
            Map(x => x.Hours);
            Map(x => x.Processed);

            //TODO
            //Map(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });

        }
    }
}
