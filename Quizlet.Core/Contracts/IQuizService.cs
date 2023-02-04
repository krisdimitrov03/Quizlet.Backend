using Quizlet.Core.Models;
using Quizlet.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IQuizService
    {
        Task<Quiz> Create(QuizCreateModel data);

        Task<bool> Remove(string id);

        Task<Quiz> Edit(QuizEditModel data);
    }
}
