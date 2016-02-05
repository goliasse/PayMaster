using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class PayorMap : ClassMap<Payor>
    {
        public PayorMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Name);
            //Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}