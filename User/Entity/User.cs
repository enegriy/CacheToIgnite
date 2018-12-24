using System;
using LinqToDB.Mapping;

namespace CacheInIgnite
{
    [Table(Name = "user")]
    public class User
    {
        [PrimaryKey, Identity]
        [Column(Name = "id")]
        public Guid Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }
    }
}
