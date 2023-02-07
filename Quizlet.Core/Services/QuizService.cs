using Quizlet.Core.Contracts;
using Quizlet.Core.Models;
using Quizlet.Infrastructure.Data.Models;
using Quizlet.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Services
{
    public class QuizService : IQuizService
    {
        private readonly IApplicationDbRepository repo;

        public QuizService(IApplicationDbRepository _repo)
        {
            this.repo = _repo;
        }

        //todo
        public async Task<Quiz?> Create(QuizCreateModel data)
        {
            var image = new Image { Url = data.ImageUrl };

            var quiz = new Quiz
            {
                CategoryId = data.CategoryId,
                CreatorId = data.CreatorId,
                Description = data.Description,
                Image = image,
                Questions = data.Questions,
                Title = data.Title
            };

            return quiz;

        }

        public Task<Quiz> Edit(QuizEditModel data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
