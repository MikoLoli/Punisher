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
    public class MeasureTypeMap : ClassMap<MeasureType>
    {
        public MeasureTypeMap()
        {
            Table("Measure Types");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Kind).CustomType<int>();
            Map(x => x.Score).CustomType<int>();
        }
    }
}
