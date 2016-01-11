using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class UseraccessMap : ClassMap<Useraccess>
    {
        public UseraccessMap()
        {
            Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Userid);
            Map(x => x.Access);
            Map(x => x.Permission);
        }
    }
}