using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServicesLifetime
{
    class Program 
    {
        static void Main()
        {
            //单例和临时服务
            //SingletonAndTransient();
            //作用域服务
            //UsingScoped();
            //自定义工厂将现有实例传递给容器
            CustomFactories();
        }

        private static void CustomFactories()
        {
            Console.WriteLine(nameof(CustomFactories));
            //局部方法
            IServiceB CreateServiceBFactory(IServiceProvider provider)
            {
               return  new ServiceB(provider.GetService<INumberService>());
            }

            ServiceProvider RegisterServices()
            {
                //创建一个对象
                var numberService = new NumberService();
                var services = new ServiceCollection();
                //将现有对象注册为单例模式
                services.AddSingleton<INumberService>(numberService);  // add existing
                //通过工厂方法注册服务
                services.AddTransient<IServiceB>(CreateServiceBFactory);  // use a factory
                services.AddSingleton<IServiceA, ServiceA>();
                return services.BuildServiceProvider();
            }

            using (ServiceProvider container = RegisterServices())
            {
                IServiceA a1 = container.GetService<IServiceA>();
                IServiceA a2 = container.GetService<IServiceA>();
                IServiceB b1 = container.GetService<IServiceB>();
                IServiceB b2 = container.GetService<IServiceB>();
            }
            Console.WriteLine();
        }

        private static void UsingScoped()
        {
            Console.WriteLine(nameof(UsingScoped));
            //局部方法
            ServiceProvider RegisterServices()
            {
                var services = new ServiceCollection();
                //注册单例服务
                services.AddSingleton<INumberService, NumberService>();
                //注册作用域服务
                services.AddScoped<IServiceA, ServiceA>();
                //注册单例服务
                services.AddSingleton<IServiceB, ServiceB>();
                //临时服务
                services.AddTransient<IServiceC, ServiceC>();
                //返回容器服务器
                return services.BuildServiceProvider();
            }

            using (ServiceProvider container = RegisterServices())
            {
                //创建自定义作用域scope1
                using (IServiceScope scope1 = container.CreateScope())
                {
                    //IServiceA--ServiceA 在容器里是作用域服务
                    //a1和a2在作用域scop1里是一个对象
                    IServiceA a1 = scope1.ServiceProvider.GetService<IServiceA>();
                    a1.A();
                    //在作用域scope1里请求创建服务A的对象a2
                    IServiceA a2 = scope1.ServiceProvider.GetService<IServiceA>();
                    a2.A();  //此时a1和a2是一个对象

                    //IServiceB--ServiceB 在容器里是单例服务
                    //ServiceB在整个程序只有一个对象
                    IServiceB b1 = scope1.ServiceProvider.GetService<IServiceB>();
                    b1.B();
                  
                    //IServiceC--ServiceC 在容器里是临时服务,C1和C2是两个对象
                    IServiceC c1 = scope1.ServiceProvider.GetService<IServiceC>();
                    c1.C();
                    IServiceC c2 = scope1.ServiceProvider.GetService<IServiceC>();
                    c2.C();
                }
                
                Console.WriteLine("scope1结束");
                //创建自定义作用域scope2 
                using (IServiceScope scope2 = container.CreateScope())
                {
                    //IServiceA--ServiceA 在容器里是作用域服务
                    //a3是与（a2和a1）不是一个对象
                    IServiceA a3 = scope2.ServiceProvider.GetService<IServiceA>();
                    a3.A();
                    //IServiceB--ServiceB 在容器里是单例服务
                    //ServiceB在整个程序只有一个对象，b2与b1都是一个对象
                    IServiceB b2 = scope2.ServiceProvider.GetService<IServiceB>();
                    b2.B();
                    //IServiceC--ServiceC 在容器里是临时服务,C1和C2及C3是三个不同的对象
                    IServiceC c3 = scope2.ServiceProvider.GetService<IServiceC>();
                    c3.C();
                }
                Console.WriteLine("scope2结束");
                Console.WriteLine();
            }
        }

        private static void SingletonAndTransient()
        {
            Console.WriteLine(nameof(SingletonAndTransient));

            //局部方法，注册服务A，服务B，NumberService和控制器类ContorllerX
            ServiceProvider RegisterServices()
            {
                IServiceCollection services = new ServiceCollection();
                services.AddSingleton<IServiceA, ServiceA>();//注册为临时服务
                services.AddTransient<IServiceB, ServiceB>();//注册为单例服务
                // services.AddSingleton<ControllerX>();//单例服务
                //注册为临时服务
                services.Add(new ServiceDescriptor(typeof(ControllerX), typeof(ControllerX), ServiceLifetime.Transient));
                services.AddSingleton<INumberService, NumberService>();//注册为单例服务
               //创建容器服务器
                return services.BuildServiceProvider();
            }

            //使用单例临时服务
            using (ServiceProvider container = RegisterServices())
            {
                //第一次请求创建ControllerX
                Console.WriteLine($"requesting {nameof(ControllerX)}");
                //创建ControllerX对象
                ControllerX x = container.GetRequiredService<ControllerX>();
                //连续调用2次M（）
                x.M();                
                x.M();
                
                //第二次请求创建ControllerX
                Console.WriteLine($"requesting {nameof(ControllerX)}");
                ControllerX x2 = container.GetRequiredService<ControllerX>();
                x2.M();

                Console.WriteLine();
            }
        }
    }
}
