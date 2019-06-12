using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 员工状态枚举
    /// create by xingbo 19/06/06
    /// </summary>
    public enum StaffStateEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled = 2,
    
    }
}
