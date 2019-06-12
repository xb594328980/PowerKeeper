using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 用户类型枚举
    /// create by xingbo 19/06/06
    /// </summary>
    public enum StaffTypeEnum
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")]
        SuperAmin = 1,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Amin = 2,
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        NormalUser = 3,
        /// <summary>
        /// 注册客户
        /// </summary>
        [Description("注册客户")]
        RegisterCustomer = 4,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")]
        Custom = 5
    }
}
