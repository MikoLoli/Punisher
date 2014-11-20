using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class EmployeeAction
    {
        public DateTime Date { get; set; }
        public string ActionDescription { get; set; }

        public void ActionAdd();

        public EmployeeAction()
        {
        }
    }
}
