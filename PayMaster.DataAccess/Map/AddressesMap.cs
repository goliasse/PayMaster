using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class AddressesMap : ClassMap<Addresses>
    {
        public AddressesMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Type).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Isprimary).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Line1);
            Map(x => x.Line2);
            Map(x => x.Line3);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.Zip);
            Map(x => x.Notes);
            References(c => c.Employees, "employeeID");
            //ManyToOne(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });
        }
    }
}