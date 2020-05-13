﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWithConfiguration
{
    public static class GreetingServiceExtensions
    {
        public static IServiceCollection AddGreetingService(this IServiceCollection collection, IConfiguration config)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (config == null) throw new ArgumentNullException(nameof(config));
            //在容器中注册配置数据
            collection.Configure<GreetingServiceOptions>(config);
            return collection.AddTransient<IGreetingService, GreetingService>();
        }
    }
}
