using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 是否启用枚举
    /// create by xingbo 19/06/06
    /// </summary>
    public enum IsEnableEnum
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable =1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled =2
    }
}
