using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 员工登录标志枚举
    /// <remarks>create by xingbo 19/01/03</remarks>
    /// </summary>
    public enum StaffLoginFlagEnum
    {
        [Description("正常")]
        Normal = 1,

        [Description("禁用")]
        Disabled = 2
    }
}
