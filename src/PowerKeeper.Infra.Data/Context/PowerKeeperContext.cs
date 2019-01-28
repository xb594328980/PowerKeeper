using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Data.Map;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PowerKeeper.Infra.Data.Context
{
    /// <summary>
    /// 权限数据库上下文
    ///  context.Office.IgnoreQueryFilters().Where();//临时禁用查询过滤器
    /// </summary>
    public class PowerKeeperContext : DbContext
    {
        public DbSet<Office> Office { get; set; }
        public DbSet<Staff> Staff { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 从 appsetting.json 中获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //定义要使用的数据库
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
            // "server=192.168.0.111;database=PowerKeeper;user=root;password=elisoft@123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfficeMap());
            modelBuilder.ApplyConfiguration(new StaffMap());
            base.OnModelCreating(modelBuilder);

        }

    }
}
