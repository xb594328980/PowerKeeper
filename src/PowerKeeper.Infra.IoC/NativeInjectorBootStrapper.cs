using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Infra.Data.Repository;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Infra.Data.Context;
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
using PowerKeeper.Infra.Identity;
using PowerKeeper.Infra.Tool.Dependency;
using Module = Autofac.Module;
using PowerKeeper.Infra.Tool.Cache.HttpRuntimeCache;
using PowerKeeper.Infra.Tool.Cache;
using Microsoft.EntityFrameworkCore;

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

            #region 身份管理器
            // 身份认证类型
            builder.RegisterType<JwtIdentity>().As<IIdentity>().InstancePerLifetimeScope();
            //身份管理器
            builder.RegisterType<IdentityManager>().InstancePerLifetimeScope();
            #endregion
            #region mediator
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            #endregion
            #region 缓存
            //builder.RegisterType<MyCacheFactory>().AsSelf();
            builder.RegisterType<MemoryCacheClient>().As<ICache>().AsSelf();
            #endregion
            #region Application
            // 注入 Application 应用层
            builder.RegisterAssemblyTypes(typeof(OfficeAppService).GetTypeInfo().Assembly).Where(x => x.FullName.EndsWith("AppService")).AsImplementedInterfaces().AsSelf().PropertiesAutowired(); ;
            #endregion
            #region Infra - Data
            // 注入 Infra - Data 基础设施数据层
            builder.RegisterAssemblyTypes(typeof(OfficeRepository).GetTypeInfo().Assembly).Where(x => x.FullName.EndsWith("Repository")).AsImplementedInterfaces().AsSelf().PropertiesAutowired();
            //DbContext
            builder.RegisterType<PowerKeeperContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
            //Handler
            builder.RegisterType<InMemoryBus>().As<IMediatorHandler>().InstancePerLifetimeScope();
            //UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            #endregion



        }

        public static void RegisterServices(IServiceCollection services)
        {

        }
    }
}
