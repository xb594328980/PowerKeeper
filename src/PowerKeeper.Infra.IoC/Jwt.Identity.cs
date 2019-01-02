using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MediatR;
using PowerKeeper.Infra.Identity;
using PowerKeeper.Infra.Tool.Dependency;

namespace PowerKeeper.Infra.IoC
{
    /// <summary>
    /// 依赖关系绑定
    /// <remarks>create by xingbo 18/12/17</remarks>
    /// </summary>
    public class Jwt_Identity : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            // 登录类型
            builder.RegisterType<JwtIdentity>().As<IIdentity>().InstancePerLifetimeScope();
        }
    }
}
