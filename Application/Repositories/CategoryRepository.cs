using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class CategoryRepository(AppDBContext appDBContext) : IRepositoty<Category>
    {
        public Task<Guid> Add(Category entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid?> Edit(Category entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
        {
            var categories = await appDBContext.Categories.Where(category => !category.DeletedAt.HasValue)
                .ToListAsync(cancellationToken);

            return categories;
        }
        public async Task<Category?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var category = await appDBContext.Categories.FirstOrDefaultAsync(act => act.Id == id);

            return category;
        }
    }
}
