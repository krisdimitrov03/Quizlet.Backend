using Microsoft.EntityFrameworkCore;
using Quizlet.Core.Contracts;
using Quizlet.Infrastructure.Data.Models;
using Quizlet.Infrastructure.Data.Repositories;

namespace Quizlet.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationDbRepository repo;

        public CategoryService(IApplicationDbRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<Category?> Create(Category data)
        {
            try
            {
                await repo.AddAsync(data);
                await repo.SaveChangesAsync();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Category?> Edit(Category data)
        {
            try
            {
                repo.Update(data);
                await repo.SaveChangesAsync();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Category>> GetAll()
        {
            return await repo.All<Category>()
                .ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await repo.All<Category>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                await repo.DeleteAsync<Category>(id);
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
