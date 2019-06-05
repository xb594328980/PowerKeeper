using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{
    /// <summary>
    /// 文件上传模式
    /// </summary>
    public enum FileUploadModeEnum
    {
        /// <summary>
        /// ftp
        /// </summary>
        [Description("ftp")]
        Ftp = 1,
        /// <summary>
        /// 本地文件
        /// </summary>
        [Description("本地文件")]
        LocalFile = 2
    }
}
