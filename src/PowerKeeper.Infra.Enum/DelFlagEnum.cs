using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 删除标志枚举
    /// <remarks>create by xingbo 18/12/21</remarks>
    /// </summary>
    public enum DelFlagEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,
        /// <summary>
        /// 已删除
        /// </summary>
        [Description("已删除")]
        Deleted = 1
    }
}
