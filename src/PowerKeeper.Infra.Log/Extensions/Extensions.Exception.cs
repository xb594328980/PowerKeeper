﻿using System;
using PowerKeeper.Infra.Tool;
using PowerKeeper.Infra.Tool.Logs;
using PowerKeeper.Infra.Tool.Exceptions;

namespace PowerKeeper.Infra.Log.Extensions {
    /// <summary>
    /// 异常扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="log">日志</param>
        public static void Log( this Exception exception, ILog log ) {
            exception = exception.GetRawException();
            if( exception is Warning warning ) {
                log.Exception( exception, warning.Code ).Warn();
                return;
            }
            log.Exception( exception ).Error();
        }
    }
}
