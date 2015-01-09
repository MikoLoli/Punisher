using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain.RepositoryExtentions
{
    public static class MeasureTypeRepositoryExtention
    {
        public static MeasureType FindByName(this IRepository<MeasureType> repository, string measureTypeName)
        {
            return repository.AsQueryable().FirstOrDefault(x => x.Name == measureTypeName);
        }
    }
}
