using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class FedTaxTableMap : ClassMap<FedTaxTable>
    {
        public FedTaxTableMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Year).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Payfrequency).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Maritalsatus).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Over).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Withhold).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Pluspercentage).Not.Nullable();//, map => map.NotNullable(true));
        }
    }
}