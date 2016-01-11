using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class EmailsMap : ClassMap<Emails>
    {
        public EmailsMap()
        {
            Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Type).Not.Nullable(); ;//, map => map.NotNullable(true));
            Map(x => x.Isprimary);
            Map(x => x.Name);
            Map(x => x.Domain);
            Map(x => x.Notes);
            //ManyToOne(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });
        }
    }
}