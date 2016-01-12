using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class PayorsMap : ClassMap<Payors>
    {
        public PayorsMap()
        {
            Schema("paymaster_dev");
            Table("payors"); 
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Name);
            //Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}