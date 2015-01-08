using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.DTO
{
    public class ActionTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WeakMeasure { get; set; }
        public string StrongMeasure { get; set; }
    }
}
