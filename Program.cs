using System;
using System.Diagnostics;
using Autofac;


namespace CacheInIgnite
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer conteiner = Conteiner.ConfigureContainer();
            var userRepository = conteiner.Resolve<CacheRepository<User, Guid>>();

            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());
            Watch(() => userRepository.GetAll());

            Console.ReadLine();
        }

        private static void Watch(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine();
        }
    }
}
