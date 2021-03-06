﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PowerKeeper.Api.Extensions;
using PowerKeeper.Api.Filters;
using PowerKeeper.Infra.Config;
using PowerKeeper.Infra.Identity;
using PowerKeeper.Infra.IoC;
using PowerKeeper.Infra.Log.Extensions;
using PowerKeeper.Infra.Mapper;
using PowerKeeper.Infra.Tool;
using PowerKeeper.Infra.Tool.Dependency;
using PowerKeeper.Infra.Tool.Helpers;
using Sansunt.HiCard.Infra.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace PowerKeeper.Api
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        #region MyRegion
        private readonly SwaggerConfig swaggerConfig = new SwaggerConfig();
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection("SwaggerConfig").Bind(swaggerConfig);
        }



        #endregion

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region Swagger
            if (swaggerConfig.Enable)
            {
                //添加Swagger
                services.AddSwaggerGen(options =>
                {
                    //swagger中控制请求的时候发是否需要在url中增加accesstoken
                    options.OperationFilter<AddAuthTokenHeaderParameter>();
                    options.SwaggerDoc("v1", new Info { Title = "PowerKeeper.Api", Version = "v1" });
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PowerKeeper.Api.xml"));
                });
            }
            #endregion
            //AutoMapper
            services.AddAutoMapperSetup();
            services.AddMvc(opt =>
            {
                opt.UseCentralRoutePrefix(new RouteAttribute("api") { });
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #region 跨域

            var urls = Configuration["AppConfig:Cores"].Split(',');
            services.AddCors(options =>
                options.AddPolicy("AllowSameDomain",
                    builder => builder.WithOrigins(urls).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
            );

            #endregion 跨域、
            //添加NLog日志操作
            services.AddNLog();
            //MediatR
            services.AddMediatR(typeof(Startup));
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            IServiceProvider serviceProvider = services.AddInfrastructure(
                new NativeInjectorBootStrapper(),
                new CommandHandlerBootStrapper(),
                new EventBootStrapper(),
                new FilterBootStrapper());//注册依赖
            IdentityManager identityManager = Ioc.Create<IdentityManager>();// new IdentityManager();
            var tokenValidationParameters = identityManager.GetTokenValidationParameters();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";
                options.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });

            return serviceProvider;
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
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseStaticFiles();
            app.UseMvc();
            app.UseAuthentication();//启用授权
            #region Swagger
            if (swaggerConfig.Enable)
            {
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
                    c.RoutePrefix = swaggerConfig.Path.Replace("\\", "/").TrimEnd('/').TrimStart('/');
                    c.SwaggerEndpoint("/docs/v1/swagger.json", "PowerKeeper.Api 接口文档");
                    //更改UI样式
                    //c.InjectStylesheet("/swagger-ui/custom.css");
                    //引入UI变更js
                    //c.InjectOnCompleteJavaScript("/swagger-ui/custom.js");
                });
            }
            #endregion Swagger
        }
    }
}
