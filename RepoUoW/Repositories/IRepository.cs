using RepoUoW.Entities;

namespace RepoUoW.Repositories
{
    public interface IRepository
    {
        Task<T?> GetAsync<T, TId>(TId id) where T : BaseEntity<TId>;
    }
}