using System;
using Apache.Ignite.Core;
using Autofac;

namespace CacheInIgnite
{
    public class Conteiner
    {
        public static IContainer ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем споставление типов
            builder.RegisterType<UserCacheRepository>().As<CacheRepository<User, Guid>>();
            builder.RegisterType<UserRepository>().As<IRepository<User>>();
            builder.RegisterInstance<IIgnite>(Ignition.Start()).SingleInstance();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            return builder.Build();
        }
    }
}
