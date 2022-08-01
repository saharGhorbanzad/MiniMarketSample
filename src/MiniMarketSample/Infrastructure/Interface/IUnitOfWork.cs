namespace Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        IProductRepository ProductRepository { get; set; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
