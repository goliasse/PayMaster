using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Paymaster.DataModel;

namespace PayMaster.DataAccess.Map
{
    public class EmployeechangelogMap : ClassMap<EmployeeChangeLog>
    {
        public EmployeechangelogMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Changedate);
            Map(x => x.From);
            Map(x => x.To);
            Map(x => x.Userid);
            //ManyToOne(x => x.Employees, map =>
            //{
            //	map.Column("employeeID");
            //	map.NotNullable(true);
            //	map.Cascade(Cascade.None);
            //});
        }
    }
}