using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 员工类型枚举
    /// <remarks>create by xingbo 19/01/03</remarks>
    /// </summary>
    public enum StaffTypeEnum
    {
        [Description("系统管理员")]
        Admin = 1,

        [Description("管理员")]
        System = 2,

        [Description("普通员工")]
        Normal = 3,

        [Description("自定义")]
        Custom = 4
    }
}
