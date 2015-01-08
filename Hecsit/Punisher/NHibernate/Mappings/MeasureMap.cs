using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Type;
using Punisher.Domain;

namespace Punisher.NHibernate.Mappings
{
    public class MeasureMap : ClassMap<Measure>
    {
        public MeasureMap()
        {
            Table("Measures");
            Id(x => x.Id);
            Map(x => x.Date).CustomType<LocalDateTimeType>();
            Map(x => x.Description);
            References(x => x.Type);
        }
    }
}
