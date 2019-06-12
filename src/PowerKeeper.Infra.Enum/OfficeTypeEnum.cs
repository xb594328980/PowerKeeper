using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 组织机构类型枚举
    /// <remarks>create by xingbo 18/12/21</remarks>
    /// </summary>
    public enum OfficeTypeEnum
    {
        /// <summary>
        /// 小组
        /// </summary>
        [Description("小组")]
        Group = 1,
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Department = 2,
        /// <summary>
        /// 公司
        /// </summary>
        [Description("公司")]
        Company = 3,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")]
        Custom = 4
    }
}
