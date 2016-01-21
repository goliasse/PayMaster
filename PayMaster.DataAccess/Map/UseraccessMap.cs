using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.Model;

namespace PayMaster.DataAccess.Map
{
    public class UseraccessMap : ClassMap<Useraccess>
    {
        public UseraccessMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Userid);
            Map(x => x.Access);
            Map(x => x.Permission);
        }
    }
}