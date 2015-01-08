using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.DTO
{
    public class MeasureDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
