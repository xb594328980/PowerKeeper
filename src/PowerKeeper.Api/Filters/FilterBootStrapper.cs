using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using PowerKeeper.Infra.Tool.Dependency;

namespace PowerKeeper.Api.Filters
{
    /// <summary>
    /// web Filter注册器
    /// create by xingbo 
    /// </summary>
    public class FilterBootStrapper : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthAttribute>().AsSelf();
            builder.RegisterType<ErrorAttribute>().AsSelf();
        }
    }
}
