using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 启用标志枚举
    /// <remarks>create by xingbo 19/1/3</remarks>
    /// </summary>
    public enum EnabledFlag
    {
        [Description("正常")]
        Normal = 1,

        [Description("禁用")]
        Disabled = 2
    }
}
