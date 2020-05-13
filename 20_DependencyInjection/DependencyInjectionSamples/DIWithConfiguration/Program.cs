using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DIWithConfiguration
{
    class Program
    {
        static void Main()
        {
            DefineConfiguration();
            var container = RegisterServices();
            var controller = container.GetService<HomeController>();
            string result = controller.Hello("小李");
            Console.WriteLine(result);
        }

        static void DefineConfiguration()
        {
            //创建一个配置构建器对象，并设置配置文件路径，添加Json文件
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            //创建配置器
            Configuration = configBuilder.Build();
        }

        public static IConfiguration Configuration { get; set; }

        static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddSingleton<IGreetingService, GreetingService>();
            //从配置器中获取GreetingService配置数据
            services.AddGreetingService(Configuration.GetSection("GreetingService"));
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }
    }
}
