using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWithOptions
{
    class Program
    {
        static void Main()
        {
            using (var container = RegisterServices())
            {
                var controller = container.GetService<HomeController>();
                string result = controller.Hello("小李");
                Console.WriteLine(result);
            }
        }

        static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
           // 添加使用选项所需的服务。
            services.AddOptions();
            services.AddGreetingService(options =>
            {
                options.From = "小张";
            });
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }
    }
}
