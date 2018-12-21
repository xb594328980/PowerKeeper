using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PowerKeeper.Domain.Core.Events;
using PowerKeeper.Infra.Data.Map;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PowerKeeper.Infra.Data.Context
{
    public class SQLEventStoreContext : DbContext
    {
        // 事件存储模型
        public DbSet<EventStore> EventStore { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 获取链接字符串
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 使用默认的sql数据库连接
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
