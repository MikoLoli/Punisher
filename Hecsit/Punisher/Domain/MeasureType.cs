using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class MeasureType
    {
        public List <string> MeasureTitle = new List <string> ();
        public int Severity { get; }
        public string MeasureTypeDescription { get; set; }

        public MeasureType()
        {
            MeasureTitle.Add("Reproof");
            MeasureTitle.Add("Payroll Deduction");
            MeasureTitle.Add("Summary Punishment");
            MeasureTitle.Add("Dismissal");
            MeasureTitle.Add("Gratitude");
            MeasureTitle.Add("Premium");
            MeasureTitle.Add("Permit");
        }
    }

    public class WeakMeasureType : MeasureType
    {

    }

    public class StrictMeasureType : MeasureType
    {

    }
}
