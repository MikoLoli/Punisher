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
    public class ActionTypeMap : ClassMap<ActionType>
    {
        public ActionTypeMap()
        {
            Table("Action Types");
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.WeakMeasure);
            References(x => x.StrongMeasure);
        }
    }
}
