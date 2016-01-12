using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class PayperiodsMap : ClassMap<Payperiods>
    {
        public PayperiodsMap()
        {
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