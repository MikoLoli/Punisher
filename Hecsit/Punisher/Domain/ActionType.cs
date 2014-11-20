using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class ActionType
    {
        public enum Title
        {
            Truancy04,
            Truancy58,
            Damage,
            Theft,
            Overtime,
            CreativeTask
        }
        public enum Type
        {
            bonus,
            punishment
        }
    }
}
