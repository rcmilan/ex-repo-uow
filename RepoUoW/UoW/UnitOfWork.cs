using Microsoft.EntityFrameworkCore;
using RepoUoW.Database;
using RepoUoW.Entities;
using RepoUoW.Repositories;
using System.Linq.Expressions;

namespace RepoUoW.UoW
{
    internal sealed class UnitOfWork : IUoW
    {
        private readonly RepoDbContext context;
        private readonly IRepository repository;

        public UnitOfWork(RepoDbContext context, IRepository repository)
        {
            this.context = context;
            this.repository = repository;

            context.BeginTransaction();
        }

        public Task<T> AddAsync<T>(T entity, bool persist = true) where T : BaseEntity => repository.AddAsync(entity, !persist);

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

        public Task<T?> GetAsync<T, TId>(TId id) where T : BaseEntity<TId> => repository.GetAsync<T, TId>(id);

        public Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy) where T : BaseEntity => repository.GetAsync(predicate, orderBy);

        public void Rollback() => context.Rollback();
    }
}