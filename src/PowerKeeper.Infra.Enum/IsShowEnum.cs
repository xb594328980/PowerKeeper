using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 是否显示枚举
    /// create by xingbo 19/06/06
    /// </summary>
    public enum IsShowEnum
    {
        /// <summary>
        /// 显示
        /// </summary>
        [Description("显示")]
        Show = 1,

        /// <summary>
        /// 隐藏
        /// </summary>
        [Description("隐藏")]
        Hide = 2,

    }
}
