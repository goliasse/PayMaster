using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class FedallowancesMap : ClassMap<Fedallowances>
    {
        public FedallowancesMap()
        {
            Schema("paymaster_dev");
            Table("fedallowances");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Year).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Payfrequency).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Eachallowanceamount).Not.Nullable();//, map => map.NotNullable(true));
        }
    }
}