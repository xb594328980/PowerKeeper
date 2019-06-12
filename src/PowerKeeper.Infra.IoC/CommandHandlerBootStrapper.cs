using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using MediatR;
using Module = Autofac.Module;
using System.Runtime.InteropServices;
using PowerKeeper.Infra.Tool.Dependency;
using PowerKeeper.Domain.CommandHandlers;
using PowerKeeper.Domain.Notifications;
using PowerKeeper.Domain.Core.Notifications;

namespace Sansunt.HiCard.Infra.IoC
{
    /// <summary>
    /// 命令注册
    /// <remarks>
    /// create by xingbo 19/05/15
    /// </remarks>
    /// </summary>
    public class CommandHandlerBootStrapper : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(OfficeCommandHandler).GetTypeInfo().Assembly).Where(x => x.FullName.EndsWith("CommandHandler")).AsImplementedInterfaces().PropertiesAutowired();
            // 将事件模型和事件处理程序匹配注入
            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>().InstancePerLifetimeScope();
        }
    }
}
