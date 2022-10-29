using Microsoft.EntityFrameworkCore;
using RepoUoW.Entities;

namespace RepoUoW.UoW
{
    public interface IUoW
    {
        void BeginTransaction();

        void Commit();

        DbSet<T> DbSet<T>() where T : BaseEntity;

        void Rollback();
    }
}