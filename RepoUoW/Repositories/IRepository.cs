using RepoUoW.Entities;
using System.Linq.Expressions;

namespace RepoUoW.Repositories
{
    public interface IRepository
    {
        Task<T?> GetAsync<T, TId>(TId id) where T : BaseEntity<TId>;

        Task<IEnumerable<T>> GetAsync<T, TOrderKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderBy) where T : BaseEntity;
    }
}