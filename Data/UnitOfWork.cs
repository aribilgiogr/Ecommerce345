using Core.Abstracts.Bases;
using Core.Utils;
using Data.Contexts;
using System.Collections;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext context;

        public UnitOfWork(ShopContext context)
        {
            this.context = context;
        }

        public async Task<int> CommitAsync() => await context.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await context.DisposeAsync();

        private Hashtable? repositories;
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            repositories ??= [];

            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repoType = typeof(Repository<>);
                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repoInstance);
            }

            return (IRepository<T>)repositories[type]!;
        }
    }
}