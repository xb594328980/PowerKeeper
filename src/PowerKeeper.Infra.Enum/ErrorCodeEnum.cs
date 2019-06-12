using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 错误代码说明
    /// </summary>
    public enum ErrorCodeEnum
    {
        /// <summary>
        /// ok
        /// </summary>
        [Description("ok")]
        ok = 0,
        /// <summary>
        /// 系统异常
        /// </summary>
        [Description("系统异常")]
        SystemException = 1001,
        /// <summary>
        /// 未登陆
        /// </summary>
        [Description("未登陆")]
        NoLogin = 1002,
        /// <summary>
        /// 逻辑异常
        /// </summary>
        [Description("逻辑异常")]
        LogicalException = 10003,
        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        OperationFailed = 1004,
        /// <summary>
        /// 无访问权限
        /// </summary>
        [Description("无访问权限")]
        NoAccess = 1005,
        /// <summary>
        /// 无任何权限
        /// </summary>
        [Description("无任何权限")]
        NoPower = 1006

    }
}
