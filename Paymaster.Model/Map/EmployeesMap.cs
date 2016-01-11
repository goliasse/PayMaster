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
    
    
    public class EmployeesMap : ClassMap<Employees> {
        
        public EmployeesMap() {
			Schema("paymaster_dev");
            DefaultLazy.Always();

            //this.ApplyFilter()

            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Number);
            Map(x => x.IsDeleted, "active").Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Socsec).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Firstname);
            Map(x => x.Lastname);
            Map(x => x.Middlename);
            Map(x => x.Payfrequency);
            Map(x => x.Hourlypayrate);
            Map(x => x.Dailyrate);
            Map(x => x.Hiredate);
            Map(x => x.Earnedincomecredit);
            Map(x => x.Earnedincomecreditchildren);
            Map(x => x.Maritalstatus);
            Map(x => x.Allowances);
            Map(x => x.Dependents);
            Map(x => x.Exemptions);
            Map(x => x.Flatfit);
            Map(x => x.Additionalwitholdingflag);
            Map(x => x.Additionalwitholdingamount);
            Map(x => x.Birthdate);
            Map(x => x.Race);
            Map(x => x.Sex);
            Map(x => x.Parttime);
            Map(x => x.Filingstatus);
            Map(x => x.State);
            Map(x => x.Uscitizen);
            Map(x => x.Createdt).Not.Update(); //TODO: remove comment //ref: http://stackoverflow.com/a/2294058
            Map(x => x.Createby);
            References(c => c.Payors, "payorId");  
            //ManyToOne(x => x.Payors, map => { map.Column("payorID"); map.Cascade(Cascade.None); });

        }
    }
}
