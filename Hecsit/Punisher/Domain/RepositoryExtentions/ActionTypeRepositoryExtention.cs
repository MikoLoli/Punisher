using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public static class ActionTypeRepositoryExtention
    {
        public static List<ActionType> FindByName(this IRepository<ActionType> repository, string actionTypeName)
        {
            return repository.AsQueryable().Where(x => x.Name == actionTypeName).ToList();
        }
    }
}
