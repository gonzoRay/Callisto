using System.Data.Entity;

namespace Callisto.Data.Repositories
{
    public abstract class BaseRepository<T> where T : DbContext
    {
        protected readonly T Context;

        public BaseRepository(T context)
        {
            Context = context;
        }
    }
}
