using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PowerKeeper.Infra.IoC;
using PowerKeeper.Infra.Mapper;
using Swashbuckle.AspNetCore.Swagger;

namespace PowerKeeper.Api
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        #region MyRegion
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #endregion

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddIocSetup();
            services.AddAutoMapperSetup();
            #region Swagger
            //添加Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "PowerKeeper.Api", Version = "v1" });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PowerKeeper.Api.xml"));
            });
            #endregion
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMediatR(typeof(Startup));
            #region autofac

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<NativeInjectorBootStrapper>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            // mediator itself
            containerBuilder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
            return container.Resolve<IServiceProvider>();
            #endregion autofac
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            #region Swagger

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c =>
            {
                //设置json路径
                c.RouteTemplate = "docs/{documentName}/swagger.json";
            });
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c =>
            {
                //访问swagger UI的路由，如http://localhost:端口/docs
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("/docs/v1/swagger.json", "PowerKeeper.Api 接口文档");
                //更改UI样式
                //c.InjectStylesheet("/swagger-ui/custom.css");
                //引入UI变更js
                //c.InjectOnCompleteJavaScript("/swagger-ui/custom.js");
            });

            #endregion Swagger

        }
    }
}
