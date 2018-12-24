namespace CacheInIgnite
{
    public class ServerContext : LinqToDB.Data.DataConnection
    {
        public ServerContext() : base("DB")
        {
        }
    }
}
