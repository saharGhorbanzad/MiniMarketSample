using Entities.Model;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<bool> AnyCategoryNameAsync(string name)
        {
            var category = await Table.Where(c => c.CategoryName == name).AnyAsync();
            return category;
        }
        public async Task<bool> AnyCategoryIdAsync(Guid? id)
        {
            var category = await Table.Where(c => c.CategoryID == id).AnyAsync();
            return category;
        }

        public async Task<string> GetCategoryNameAsync(Guid? categoryId)
        {
            var category = await Table.Where(c => c.CategoryID == categoryId).SingleOrDefaultAsync();
            return category.CategoryName;
        }
    }
}
