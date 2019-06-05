using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Config
{
    public class FtpBaseConfig
    {
        /// <summary>
        /// FTP上传地址
        /// </summary>
        public string FtpAddress { get; set; }
        /// <summary>
        /// 登录账户
        /// </summary>
        public string FtpUser { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string FtpPwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FtpHeadDire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FtpBwDire { get; set; }
        /// <summary>
        /// 展示地址
        /// </summary>
        public string WebUrl { get; set; }
    }
}
