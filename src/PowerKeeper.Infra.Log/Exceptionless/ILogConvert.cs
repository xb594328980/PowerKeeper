using PowerKeeper.Infra.Tool;
using System.Collections.Generic;

namespace PowerKeeper.Infra.Log.Exceptionless {
    /// <summary>
    /// 日志转换器
    /// </summary>
    public interface ILogConvert {
        /// <summary>
        /// 转换
        /// </summary>
        List<Item> To();
    }
}
