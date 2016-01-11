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
    
    
    public class EmployeechangelogMap : ClassMap<Employeechangelog> {
        
        public EmployeechangelogMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Changedate);
            Map(x => x.From);
            Map(x => x.To);
            Map(x => x.Userid);
			//ManyToOne(x => x.Employees, map => 
			//{
			//	map.Column("employeeID");
			//	map.NotNullable(true);
			//	map.Cascade(Cascade.None);
			//});

        }
    }
}
