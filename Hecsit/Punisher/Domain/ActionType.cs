using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class ActionType
    {
        public List <string> Title = new List <string> ();
        public List <string> Type = new List <string> ();

        public ActionType()
        {
            Title.Add("Truancy04");
            Title.Add("Truancy58");
            Title.Add("Damage");
            Title.Add("Theft");
            Title.Add("Overtime");
            Title.Add("CreativeTask");

            Type.Add("Bonus");
            Type.Add("Punishment");
        }

        public void ActionTypeAdd ( string title)
        {
            Title.Add(title);
        }
    }
}
