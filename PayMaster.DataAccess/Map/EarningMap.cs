using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class EarningMap : ClassMap<Earning>
    {
        public EarningMap()
        {
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