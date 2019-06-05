using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PowerKeeper.Infra.Enum
{

    /// <summary>
    /// 上传文件类型枚举
    /// <remarks>create by xingbo 19/05/17</remarks>
    /// </summary>
    public enum FileTypeEnum
    {
        /// <summary>
        /// 二维码
        /// </summary>
        [Description("二维码")]
        QrCode = 0,
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        Pic = 1,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        Video = 2
    }
}
