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
    public class ActionMap : ClassMap<EmployeeAction>
    {
        public ActionMap()
        {
            Table("Actions");
            Id(x => x.Id);
            References(x => x.Employee);
            Map(x => x.Date).CustomType<LocalDateTimeType>();
            Map(x => x.Description);
            References(x => x.Type);
            References(x => x.Measure);
        }
    }
}
