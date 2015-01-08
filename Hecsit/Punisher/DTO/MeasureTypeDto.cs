using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.DTO
{
    public class MeasureTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public int Score { get; set; }
    }
}
