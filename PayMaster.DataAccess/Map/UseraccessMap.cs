using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class UserAccessMap : ClassMap<UserAccess>
    {
        public UserAccessMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Userid);
            Map(x => x.Access);
            Map(x => x.Permission);
        }
    }
}