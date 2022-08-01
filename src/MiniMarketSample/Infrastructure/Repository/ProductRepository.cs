using Entities.Model;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var prodct = await Table.Where(p => p.ProductID == id).FirstOrDefaultAsync(cancellationToken);
            return prodct;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid? categoryId, CancellationToken cancellationToken)
        {
            var productCategoryed = await Table.Where(p => p.CategoryID == categoryId).ToListAsync(cancellationToken);
            return productCategoryed;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken)
        {
            var products = await TableNoTracking.Where(s => s.ProductName == name).ToListAsync(cancellationToken);
            return products;

        }
    }
}
