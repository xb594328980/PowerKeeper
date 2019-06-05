using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MediatR;
using PowerKeeper.Application.EventSourcing;
using PowerKeeper.Domain.Core.Events;
using PowerKeeper.Domain.EventHandlers;
using PowerKeeper.Domain.Events.Office;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Infra.Data.Context;
using PowerKeeper.Infra.Data.Repository;
using PowerKeeper.Infra.Tool.Dependency;

namespace Sansunt.HiCard.Infra.IoC
{
    /// <summary>
    /// 事件注册
    /// <remarks>
    /// create by xingbo 19/05/15
    /// </remarks>
    /// </summary>
    public class EventBootStrapper : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeCreatedEvent>>();
            // Domain - Events
            // 将事件模型和事件处理程序匹配注入
            builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeCreatedEvent>>();
            builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeUpdatedEvent>>();
            builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeRemovedEvent>>();

            //event sourceing
            builder.RegisterType<SqlEventStoreService>().As<IEventStoreService>();
            builder.RegisterType<EventStoreRepository>().As<IEventStoreRepository>();
            builder.RegisterType<SQLEventStoreContext>().InstancePerLifetimeScope();
        }
    }
}
