using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.Model;

namespace PayMaster.DataAccess.Map
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Username).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Password).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Locked);
            Map(x => x.Sessionid);
            Map(x => x.Sessionstart);
            Map(x => x.Sessionend);
            References(c => c.Payors, "payorId");
            //ManyToOne(x => x.Payors, map => { map.Column("payorID"); map.Cascade(Cascade.None); });
        }
    }
}