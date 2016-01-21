using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.Model;

namespace PayMaster.DataAccess.Map
{
    public class PayorsMap : ClassMap<Payors>
    {
        public PayorsMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Name);
            //Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}