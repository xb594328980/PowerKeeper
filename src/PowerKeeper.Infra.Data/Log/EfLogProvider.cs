﻿using Microsoft.Extensions.Logging;

namespace PowerKeeper.Infra.Data.Log
{
    /// <summary>
    /// Ef日志提供器
    /// </summary>
    public class EfLogProvider : ILoggerProvider {
        /// <summary>
        /// 初始化Ef日志提供器
        /// </summary>
        /// <param name="category">日志分类</param>
        public ILogger CreateLogger( string category ) {
            return category.StartsWith( "Microsoft.EntityFrameworkCore" ) ? new EfLog() : NullLogger.Instance;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose() {
        }
    }
}
