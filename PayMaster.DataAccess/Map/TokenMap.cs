using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class TokenMap : ClassMap<Token>
    {
        public TokenMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.UserId);
            Map(x => x.AuthToken);
            Map(x => x.IssuedOn);
            Map(x => x.ExpiresOn);
            //References(c => c.UserId, "UserId");
        }
    }
}