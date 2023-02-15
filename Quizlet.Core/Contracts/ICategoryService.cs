using Quizlet.Infrastructure.Data.Models;

namespace Quizlet.Core.Contracts
{
    public interface ICategoryService 
        : IEntityService<Category, Category, int, Category>
    {
    }
}
