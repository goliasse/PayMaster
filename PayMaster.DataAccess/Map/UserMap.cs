using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Locked);
            Map(x => x.SessionId);
            Map(x => x.SessionStart);
            Map(x => x.SessionEnd);
            Map(x => x.Roles);
            References(c => c.Payor, "payorId");
            //ManyToOne(x => x.Payors, map => { map.Column("payorID"); map.Cascade(Cascade.None); });
        }
    }
}