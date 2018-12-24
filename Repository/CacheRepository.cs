using System;
using System.Collections.Generic;
using System.Linq;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Query;

namespace CacheInIgnite
{
    public abstract class CacheRepository<T, TId> : IRepository<T>
    {
        protected Func<T, TId> MethodCalcId { get; set; }

        protected readonly ICache<TId, T> Cache;
        protected readonly IRepository<T> Repository;

        public CacheRepository(
            IRepository<T> repository,
            IIgnite ignite,
            string nameRepository,
            Func<T, TId> methodCalcId)
        {
            Cache = ignite.GetOrCreateCache<TId, T>(nameRepository);
            Repository = repository;
            MethodCalcId = methodCalcId;
        }

        public IList<T> GetAll()
        {
            Console.WriteLine("select users from cache");

            var items = GetAllFromCache();
            if (!items.Any())
            {
                Console.WriteLine("users from cache is not found");
                var list = GetAllFromRepository();
                AddToCache(list);
                return list;
            }
            return items;
        }

        private IList<T> GetAllFromCache()
        {
            var queryCursor = Cache.Query(new ScanQuery<TId, T>());
            return queryCursor.Select(x => x.Value).ToList();
        }

        private void AddToCache(IEnumerable<T> users)
        {
            foreach (var user in users)
            {
                AddToCache(user);
            }
        }

        private void AddToCache(T item)
        {
            Cache.Put(MethodCalcId(item), item);
        }

        private IList<T> GetAllFromRepository()
        {
            return  Repository.GetAll();
        }
    }
}
