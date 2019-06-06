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
        [Description("ok")]
        ok = 0,
        [Description("系统异常")]
        SystemException = 1001,
        [Description("未登陆")]
        NoLogin = 1002,
        [Description("逻辑异常")]
        LogicalException = 10003,
        [Description("操作失败")]
        OperationFailed = 1004,
        [Description("无访问权限")]
        NoAccess = 1005,
        [Description("无任何权限")]
        NoPower = 1006

    }
}
