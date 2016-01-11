using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class ChecksMap : ClassMap<Checks>
    {
        public ChecksMap()
        {
            Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Employeeid);
            Map(x => x.Amount);
            Map(x => x.Checknumber);
            Map(x => x.Checkdate);
            Map(x => x.Banknumber);
            Map(x => x.Accountnumber);
            Map(x => x.Lastname);
            Map(x => x.Firstname);
            Map(x => x.Voidflag);

            //ManyToOne(x => x.Payperiods, map => { map.Column("payPeriodID"); map.Cascade(Cascade.None); });
        }
    }
}