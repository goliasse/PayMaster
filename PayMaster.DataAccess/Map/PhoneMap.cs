using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class PhoneMap : ClassMap<Phone>
    {
        public PhoneMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Type).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Isprimary);
            Map(x => x.Number);
            Map(x => x.Notes);
            //ManyToOne(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });
        }
    }
}