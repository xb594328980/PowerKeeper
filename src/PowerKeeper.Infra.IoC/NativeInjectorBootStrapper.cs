using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Infra.Data.Repository;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Infra.Data.Context;
using Christ3D.Infrastruct.Data.Repository;
using PowerKeeper.Application.Services;
using PowerKeeper.Application.Interfaces;
using System.Reflection;
using Autofac.Core;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Infra.Bus;
using PowerKeeper.Infra.Data.UoW;
using MediatR;
using PowerKeeper.Domain.CommandHandlers;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.EventHandlers;
using PowerKeeper.Domain.Events.Office;
using PowerKeeper.Domain.Notifications;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Domain.Core.Events;
using PowerKeeper.Application.EventSourcing;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Events.Staff;
using PowerKeeper.Infra.Identity;
using PowerKeeper.Infra.Tool.Dependency;
using Module = Autofac.Module;

namespace PowerKeeper.Infra.IoC
{
    /// <summary>
    /// 依赖关系绑定
    /// <remarks>create by xingbo 18/12/17</remarks>
    /// </summary>
    public class NativeInjectorBootStrapper : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityManager>().InstancePerLifetimeScope();
            // mediator 
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            // 注入 Application 应用层
            builder.RegisterAssemblyTypes(typeof(OfficeAppService).GetTypeInfo().Assembly).AsImplementedInterfaces().AsSelf().PropertiesAutowired();
            //builder.RegisterType<OfficeAppService>().As<IOfficeAppService>();
            // .InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(LogAOP));//可以直接替换拦截器;

            builder.RegisterType<InMemoryBus>().As<IMediatorHandler>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // 注入 Infra - Data 基础设施数据层
            //builder.RegisterType<OfficeRepository>().As<IOfficeRepository>();

            builder.RegisterAssemblyTypes(typeof(OfficeRepository).GetTypeInfo().Assembly).AsImplementedInterfaces().AsSelf().PropertiesAutowired();//Repository

            builder.RegisterType<PowerKeeperContext>().InstancePerLifetimeScope();

            //将命令模型和命令处理程序匹配注入
            builder.RegisterType<OfficeCommandHandler>().As<IRequestHandler<CreateOfficeCommand, Unit>>();
            builder.RegisterType<OfficeCommandHandler>().As<IRequestHandler<UpdateOfficeCommand, Unit>>();
            builder.RegisterType<OfficeCommandHandler>().As<IRequestHandler<DeleteOfficeCommand, Unit>>();

            builder.RegisterType<StaffCommandHandler>().As<IRequestHandler<CreateStaffCommand, Unit>>();
            builder.RegisterType<StaffCommandHandler>().As<IRequestHandler<UpdateStaffCommand, Unit>>();
            builder.RegisterType<StaffCommandHandler>().As<IRequestHandler<DeleteStaffCommand, Unit>>();

            // Domain - Events
            // 将事件模型和事件处理程序匹配注入
            builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeCreatedEvent>>();
            builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeUpdatedEvent>>();
            builder.RegisterType<OfficeEventHandler>().As<INotificationHandler<OfficeDeletedEvent>>();

            builder.RegisterType<StaffEventHandler>().As<INotificationHandler<StaffCreatedEvent>>();
            builder.RegisterType<StaffEventHandler>().As<INotificationHandler<StaffUpdatedEvent>>();
            builder.RegisterType<StaffEventHandler>().As<INotificationHandler<StaffDeletedEvent>>();

            // 将事件模型和事件处理程序匹配注入
            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>().InstancePerLifetimeScope();

            //event sourceing
            builder.RegisterType<SqlEventStoreService>().As<IEventStoreService>();
            builder.RegisterType<EventStoreRepository>().As<IEventStoreRepository>();
            builder.RegisterType<SQLEventStoreContext>().InstancePerLifetimeScope();

            
        }

        public static void RegisterServices(IServiceCollection services)
        {

        }
    }
}
