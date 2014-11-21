using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class EmployeeAction
    {
        public DateTime ActionDate { get; set; }
        public string ActionDescription { get; set; }

        public EmployeeAction ( DateTime actionDate, string actionDescription)
        {
            ActionDate = actionDate;
            ActionDescription = actionDescription;
        }
    }
}
