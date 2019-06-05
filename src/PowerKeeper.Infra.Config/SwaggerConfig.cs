using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Config
{
    /// <summary>
    /// Swagger配置
    /// create  by  xingbo 19/06/05
    /// </summary>
    public class SwaggerConfig
    {
        public SwaggerConfig()
        {
            Enable = false;
            Path = "docs";
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        public string Path { get; set; }
    }
}
