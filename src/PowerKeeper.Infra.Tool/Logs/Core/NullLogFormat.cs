using PowerKeeper.Infra.Tool.Logs.Abstractions;

namespace PowerKeeper.Infra.Tool.Logs.Core {
    /// <summary>
    /// 空日志格式器
    /// </summary>
    public class NullLogFormat : ILogFormat {
        /// <summary>
        /// 空日志格式器实例
        /// </summary>
        public static readonly ILogFormat Instance = new NullLogFormat();

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="content">日志内容</param>
        public string Format( ILogContent content ) {
            return "";
        }
    }
}
