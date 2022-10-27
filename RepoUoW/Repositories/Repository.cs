using Microsoft.EntityFrameworkCore;
using RepoUoW.Database;
using RepoUoW.Entities;
using System.Linq.Expressions;

namespace RepoUoW.Repositories
{
    internal sealed class Repository : IRepository
    {
        private readonly RepoDbContext context;

        public Repository(RepoDbContext context)
        {
            this.context = context;
        }

        public async Task<T?> GetAsync<T, TId>(TId id) where T : BaseEntity<TId>
            => await context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy) where T : BaseEntity
            => await context.Set<T>().Where(predicate).OrderBy(orderBy).ToListAsync();
    }
}