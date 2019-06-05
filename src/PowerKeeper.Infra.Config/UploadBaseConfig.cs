using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Config
{
    /// <summary>
    /// 上传基础配置
    /// Create by xingbo 19/05/24
    /// update by xingbo
    /// </summary>
    public class UploadBaseConfig
    {
        /// <summary>
        /// 单文件夹最大存储目录数量
        /// </summary>
        public int MaxFolderCnt { get; set; }
        /// <summary>
        /// 单文件夹最大存储文件数据
        /// </summary>
        public int MaxFileCnt { get; set; }
        /// <summary>
        /// 本地存储目录
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 本地图片文件web服务器
        /// </summary>
        public string WebUrl { get; set; }
    }
}
