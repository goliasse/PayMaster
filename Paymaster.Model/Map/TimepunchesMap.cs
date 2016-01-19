using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class TimepunchesMap : ClassMap<Timepunches>
    {
        public TimepunchesMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Indatetime);
            Map(x => x.Outdatetime);
            Map(x => x.Referencedate);
            Map(x => x.Hours);
            Map(x => x.Hourlypayrate);
            Map(x => x.Dailyrate);
            Map(x => x.Processed);

            //TODO
            //Map(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });
        }
    }
}