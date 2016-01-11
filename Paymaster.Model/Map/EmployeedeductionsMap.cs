using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class EmployeedeductionsMap : ClassMap<Employeedeductions>
    {
        public EmployeedeductionsMap()
        {
            Schema("paymaster_dev");
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Description);
            Map(x => x.Frequency).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Skip).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Amountflag);
            Map(x => x.Amount);
            Map(x => x.Annuallimit);
            //ManyToOne(x => x.Employees, map => { map.Column("employeeID"); map.Cascade(Cascade.None); });
        }
    }
}