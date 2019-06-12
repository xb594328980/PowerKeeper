using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Data.Map;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;
using PowerKeeper.Infra.Config;
using PowerKeeper.Infra.Data.Log;
using PowerKeeper.Infra.Tool.Helpers;
using PowerKeeper.Infra.Tool.Logs;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Log;

namespace PowerKeeper.Infra.Data.Context
{
    public class PowerKeeperContext : DbContext
    {
        /// <summary>
        /// 日志工厂
        /// </summary>
        private readonly ILoggerFactory LoggerFactory;
        private DbConnection _connection;

        public PowerKeeperContext(DbConnection connection)
        {
            _connection = connection;
        }
        public PowerKeeperContext() : base()
        {
            LoggerFactory = new LoggerFactory(new[] { new EfLogProvider() });
        }
        public DbSet<Office> Office { get; set; }
        /// <summary>
        /// 员工表
        /// create by xingbo 19/06/06
        /// </summary>
        public DbSet<Staff> Staff { get; set; }

        /// <summary>
        /// 角色表
        /// create by xingbo 19/06/06
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// 资源表，包含菜单、按钮、接口等
        /// create by xingbo 19/06/06
        /// </summary>
        public DbSet<Resource> Resource { get; set; }

        /// <summary>
        /// 员工角色对应关系
        /// create by xingbo 19/06/06
        /// </summary>
        public DbSet<StaffRole> StaffRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 从 appsetting.json 中获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            if (_connection != null)
                optionsBuilder.UseMySql(_connection);
            else
                optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));  //定义要使用的数据库
            // "server=192.168.0.111;database=PowerKeeper;user=root;password=elisoft@123;");
            EnableLog(optionsBuilder);//配置日志
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfficeMap());
            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new ResourceMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new StaffRoleMap());


            base.OnModelCreating(modelBuilder);

        }

        /// <summary>
        /// 启用日志
        /// </summary>
        protected void EnableLog(DbContextOptionsBuilder builder)
        {
            var log = GetLog();
            if (IsEnabled(log) == false)
                return;
            builder.EnableSensitiveDataLogging();
            builder.EnableDetailedErrors();
            builder.UseLoggerFactory(LoggerFactory);
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog()
        {
            try
            {
                return Infra.Log.Log.GetLog(EfLog.TraceLogName);
            }
            catch
            {
                return Infra.Log.Log.Null;
            }
        }

        /// <summary>
        /// 是否启用Ef日志
        /// </summary>
        private bool IsEnabled(ILog log)
        {
            var config = GetConfig();
            if (config.EfLogLevel == EfLogLevel.Off)
                return false;
            if (log.IsTraceEnabled == false)
                return false;
            return true;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private EfConfig GetConfig()
        {
            try
            {
                var options = Ioc.Create<ConfigManage>();
                return options.EfConfig;
            }
            catch
            {
                return new EfConfig { EfLogLevel = EfLogLevel.Sql };
            }
        }
    }
}
