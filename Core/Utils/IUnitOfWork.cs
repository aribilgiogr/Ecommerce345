using Core.Abstracts.Bases;

namespace Core.Utils
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> CommitAsync();
    }
}
