using Entities.Interface;

namespace Infrastructure.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        void AddEntity(T model);
        void AddRangeEntities(IEnumerable<T> models);

        Task AddEntityAsync(T model, CancellationToken cancellationToken);
        Task AddRangeEntitesAsync(IEnumerable<T> models, CancellationToken cancellationToken);

        void UpdateEntity(T model);
        void UpdateEntites(IEnumerable<T> models);

        void RemoveEntity(T model);
        void RemoveEntities(IEnumerable<T> models);
    }
}
