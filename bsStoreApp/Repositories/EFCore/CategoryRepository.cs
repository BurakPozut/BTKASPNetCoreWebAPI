using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) :
            base(context)
        {
        }

        public void CreateOneCategory(Category category) =>
            Create(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CategoryName).ToListAsync();
        }

        public Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return FindByCondition(c => c.CategoryId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

    }
}
