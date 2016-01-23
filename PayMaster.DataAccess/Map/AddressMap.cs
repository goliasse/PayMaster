using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Isprimary).Not.Nullable();
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