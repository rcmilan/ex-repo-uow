using RepoUoW.Repositories;

namespace RepoUoW.UoW
{
    public interface IUoW : IRepository
    {
        Task Commit();
    }
}