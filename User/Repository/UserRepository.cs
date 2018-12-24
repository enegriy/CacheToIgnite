using System;
using System.Collections.Generic;
using System.Linq;

namespace CacheInIgnite
{
    public class UserRepository : ServerContext, IRepository<User>
    {
        public IList<User> GetAll()
        {
            Console.WriteLine("select users from database");
            return GetTable<User>().ToList();
        }
    }
}
