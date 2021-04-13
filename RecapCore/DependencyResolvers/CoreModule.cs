using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RecapCore.CrossCuttingConcerns.Caching;
using RecapCore.CrossCuttingConcerns.Caching.Microsoft;
using RecapCore.Utility.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RecapCore.DependencyResolvers
{
    public class CoreModule: ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
