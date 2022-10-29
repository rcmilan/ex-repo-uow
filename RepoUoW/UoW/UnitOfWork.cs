using Microsoft.EntityFrameworkCore;
using RepoUoW.Database;
using RepoUoW.Entities;

namespace RepoUoW.UoW
{
    internal sealed class UnitOfWork : IUoW
    {
        private readonly RepoDbContext context;

        public UnitOfWork(RepoDbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction() => context.BeginTransaction();

        public void Commit() => context.Commit();

        public DbSet<T> DbSet<T>() where T : BaseEntity => context.Set<T>();

        public void Rollback() => context.Rollback();
    }
}