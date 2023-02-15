using Quizlet.Core.Models.Quiz;
using Quizlet.Infrastructure.Data.Models;

namespace Quizlet.Core.Contracts
{
    public interface IQuizService 
        : IEntityService<Quiz, QuizCreateModel, string, QuizEditModel>
    {
    }
}
