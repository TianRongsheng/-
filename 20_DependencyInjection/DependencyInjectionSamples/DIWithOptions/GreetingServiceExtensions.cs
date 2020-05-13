using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWithOptions
{
   
    public static class GreetingServiceExtensions
    {
        //为便于使用DI容器注册服务，定义IServiceCollection的扩展方法
        //允许通过委托传递GreetingServiceOptions
        public static IServiceCollection AddGreetingService(this IServiceCollection collection,
            Action<GreetingServiceOptions> setupAction)
        {
            //异常处理
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));
            //注册用于配置特定类型的选项的操作,通过委托GreetingServiceOptions
            collection.Configure(setupAction);
            return collection.AddTransient<IGreetingService, GreetingService>();
        }
    }
}
