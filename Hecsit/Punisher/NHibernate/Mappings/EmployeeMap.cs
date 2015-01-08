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
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            Id(x => x.Id);
            Map(x => x.FIO);
            Map(x => x.PersonnelNumber);
            Map(x => x.RecruitmentDate).CustomType<LocalDateTimeType>();
            Map(x => x.Reputation).CustomType<int>();
            Map(x => x.Position);
            Map(x => x.WageRate).CustomType<decimal>();
            Map(x => x.Salary).CustomType<decimal>();
            References(x => x.EmployeeActions);
        }
    }
}
