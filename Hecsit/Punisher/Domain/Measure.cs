using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class Measure
    {
        public DateTime Date { get; set; }
        public string MeasureDescription { get; set; }

        public void Approve();
    }
}
