using System.Collections.Generic;

namespace CacheInIgnite
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
    }
}
