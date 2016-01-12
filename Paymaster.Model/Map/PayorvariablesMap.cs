using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Paymaster.Model.Maps
{
    public class PayorvariablesMap : ClassMap<Payorvariables>
    {
        public PayorvariablesMap()
        {
            DefaultLazy.Always();
            Id(x => x.Id);//, map => map.Generator(Generators.Assigned));
            Map(x => x.Flag1).Not.Nullable();//, map => map.NotNullable(true));
            Map(x => x.Value1);
            //ManyToOne(x => x.Payors, map => { map.Column("payorID"); map.Cascade(Cascade.None); });
        }
    }
}