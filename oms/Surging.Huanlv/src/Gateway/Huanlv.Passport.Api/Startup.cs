using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Huanlv.Passport.IApplication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Surging.Core.Caching.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusRabbitMQ.Configurations;
using Surging.Core.ProxyGenerator;

namespace Huanlv.Passport.Api
{
    public class Startup
    {
        private ContainerBuilder _builder;
        public Startup(IConfigurationBuilder config)
        {
            ConfigureEventBus(config);
            ConfigureCache(config);
        }

        public IContainer ConfigureServices(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            ConfigureLogging(services);
            builder.Populate(services);
            _builder = builder;
            ServiceLocator.Current = builder.Build();
            return ServiceLocator.Current;
        }

        public void Configure(IContainer app)
        {

        }

        #region ˽�з���
        /// <summary>
        /// ������־����
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging();
        }

        private static void ConfigureEventBus(IConfigurationBuilder build)
        {
            build
            .AddEventBusFile("eventBusSettings.json", optional: false);
        }

        /// <summary>
        /// ���û������
        /// </summary>
        private void ConfigureCache(IConfigurationBuilder build)
        {
            build
              .AddCacheFile("cacheSettings.json", optional: false);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="serviceProxyFactory"></param>
        public static void Test(IServiceProxyFactory serviceProxyFactory)
        {
            Task.Run(async () =>
            {
                var userProxy = serviceProxyFactory.CreateProxy<IUserService>("User");

                var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();

                do
                {
                    Console.WriteLine("����ѭ�� 1w�ε��� GetUser.....");

                    //1w�ε���
                    var watch = Stopwatch.StartNew();
                    for (var i = 0; i < 10000; i++)
                    {
                        //var a = userProxy.GetDictionary().Result;
                        var a = await userProxy.GetUserById(1, 1);
                        //var result = serviceProxyProvider.Invoke<object>(new Dictionary<string, object>(), "api/user/GetDictionary", "User").Result;
                    }
                    watch.Stop();
                    Console.WriteLine($"1w�ε��ý�����ִ��ʱ�䣺{watch.ElapsedMilliseconds}ms");
                    Console.WriteLine("Press any key to continue, q to exit the loop...");
                    var key = Console.ReadLine();
                    if (key.ToLower() == "q")
                        break;
                } while (true);
            }).Wait();
        }

        //public static void TestRabbitMq(IServiceProxyFactory serviceProxyFactory)
        //{
        //    serviceProxyFactory.CreateProxy<IUserService>("User").PublishThroughEventBusAsync(new UserEvent()
        //    {
        //        Age = 18,
        //        Name = "fanly",
        //        UserId = 1
        //    });
        //    Console.WriteLine("Press any key to exit...");
        //    Console.ReadLine();
        //}

        //public static void TestForRoutePath(IServiceProxyProvider serviceProxyProvider)
        //{
        //    Dictionary<string, object> model = new Dictionary<string, object>();
        //    model.Add("user", JsonConvert.SerializeObject(new
        //    {
        //        Name = "fanly",
        //        Age = 18,
        //        UserId = 1
        //    }));
        //    string path = "api/user/getuser";
        //    string serviceKey = "User";

        //    var userProxy = serviceProxyProvider.Invoke<object>(model, path, serviceKey);
        //    var s = userProxy.Result;
        //    Console.WriteLine("Press any key to exit...");
        //    Console.ReadLine();
        //}
        #endregion

    }
}
