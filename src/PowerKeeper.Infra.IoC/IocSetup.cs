using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerKeeper.Infra.IoC
{
    public static class IocSetup
    {
        public static void AddIocSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            // .NET Core 原生依赖注入
            // 单写一层用来添加依赖项，可以将IoC与展示层 Presentation 隔离
            NativeInjectorBootStrapper.RegisterServices(services);

        }
    }
}
