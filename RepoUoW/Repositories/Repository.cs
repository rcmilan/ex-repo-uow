using Microsoft.EntityFrameworkCore;
using RepoUoW.Database;
using RepoUoW.Entities;

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
    }
}