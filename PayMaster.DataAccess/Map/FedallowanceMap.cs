using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class FedallowanceMap : ClassMap<FedAllowance>
    {
        public FedallowanceMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Year).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Payfrequency).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Eachallowanceamount).Not.Nullable();//, map => map.NotNullable(true));
        }
    }
}