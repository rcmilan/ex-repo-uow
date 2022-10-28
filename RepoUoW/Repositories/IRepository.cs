using RepoUoW.Entities;
using System.Linq.Expressions;

namespace RepoUoW.Repositories
{
    public interface IRepository
    {
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

        Task<T?> GetAsync<T, TId>(TId id) where T : BaseEntity<TId>;

        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy) where T : BaseEntity;

        int Commit();
    }
}