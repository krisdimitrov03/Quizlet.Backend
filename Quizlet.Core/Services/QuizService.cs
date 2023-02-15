using Microsoft.EntityFrameworkCore;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Quiz;
using Quizlet.Infrastructure.Data.Models;
using Quizlet.Infrastructure.Data.Repositories;

namespace Quizlet.Core.Services
{
    public class QuizService : IQuizService
    {
        private readonly IApplicationDbRepository repo;

        public QuizService(IApplicationDbRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<Quiz?> Create(QuizCreateModel data)
        {
            try
            {
                await repo.AddRangeAsync(data.Questions);

                var image = new Image()
                {
                    Url = data.ImageUrl
                };
                await repo.AddAsync(image);
                await repo.SaveChangesAsync();

                var quiz = new Quiz
                {
                    Questions = data.Questions,
                    CategoryId = data.CategoryId,
                    CreatorId = data.CreatorId,
                    Image = image,
                    Description = data.Description,
                    Title = data.Title
                };

                await repo.AddAsync(quiz);
                await repo.SaveChangesAsync();

                return quiz;
            }
            catch (Exception)
            {
                return null;
            }

        }

        //todo
        public async Task<Quiz?> Edit(QuizEditModel data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Quiz>> GetAll()
        {
            return await repo.All<Quiz>()
                .Include(x => x.Category)
                .Include(x => x.Image)
                .Include(x => x.Creator)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Options)
                .ToListAsync();
        }

        public async Task<Quiz?> GetById(string id)
        {
            var quizes = await GetAll();

            return quizes
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                await repo.DeleteAsync<Quiz>(id);
                await repo.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
