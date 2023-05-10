using Microsoft.EntityFrameworkCore;
using RepoUoW.Database;
using RepoUoW.Entities;
using System.Linq.Expressions;

namespace RepoUoW.UoW
{
    internal sealed class UnitOfWork : IUoW
    {
        private readonly RepoDbContext context;

        public UnitOfWork(RepoDbContext context)
        {
            this.context = context;

            context.BeginTransaction();
        }

        public async Task<T> AddAsync<T>(T entity, bool persist = true) where T : BaseEntity
        {
            await context.Set<T>().AddAsync(entity);

            return entity;
        }

        public Task Commit()
        {
            try
            {
                context.Commit();
            }
            catch (Exception)
            {
                context.Rollback();
            }

            context.DisposeAsync();

            return Task.CompletedTask;
        }

        public DbSet<T> DbSet<T>() where T : BaseEntity => context.Set<T>();

        public async Task<T?> GetAsync<T, TId>(TId id) where T : BaseEntity<TId>
            => await context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy) where T : BaseEntity
            => await context.Set<T>().Where(predicate).OrderBy(orderBy).ToListAsync();

        public void Rollback() => context.Rollback();
    }
}