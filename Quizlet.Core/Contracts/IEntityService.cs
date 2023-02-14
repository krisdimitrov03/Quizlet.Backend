using Quizlet.Core.Models;
using Quizlet.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IEntityService<T, TGetCreate, TId, TGetEdit>
        where T : class
    {
        Task<T?> Create(TGetCreate data);

        Task<bool> Remove(TId id);

        Task<T?> Edit(TGetEdit data);
    }
}
