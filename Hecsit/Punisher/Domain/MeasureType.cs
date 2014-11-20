using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class MeasureType
    {
        public enum MeasureTitle
        {
            Reproof,
            PayrollDeduction,
            SummaryPunishment,
            Dismissal,
            Gratitude,
            Premium,
            Permit
        }
        public int Severity { get; }
        public string MeasureTypeDescription { get; set; }

    }

    public class WeakMeasureType : MeasureType
    {

    }

    public class StrictMeasureType : MeasureType
    {

    }
}
