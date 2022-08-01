using Entities.Model;

namespace Infrastructure.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> AnyCategoryNameAsync(string name);
        Task<bool> AnyCategoryIdAsync(Guid? id);
        Task<string> GetCategoryNameAsync(Guid? categoryId);
    }
}
