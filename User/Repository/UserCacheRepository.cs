using Apache.Ignite.Core;
using System;

namespace CacheInIgnite
{
    public class UserCacheRepository : CacheRepository<User, Guid>
    {
        public UserCacheRepository(IRepository<User> userRepository, IIgnite ignite) 
            : base(userRepository, ignite, "UserCacheRepository", user => user.Id)
        {
        }
    }
}
