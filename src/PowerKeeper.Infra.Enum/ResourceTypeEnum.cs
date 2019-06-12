using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 资源类型枚举
    /// create by xingbo 19/06/06
    /// </summary>
    public enum ResourceTypeEnum
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu = 1,
        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        Button = 2,
        /// <summary>
        /// 接口
        /// </summary>
        [Description("接口")]
        Interface = 3,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")]
        Custom = 4
    }
}
