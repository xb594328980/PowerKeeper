using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PowerKeeper.Api.App_Helper
{
    /// <summary>
    /// 通用值返回模型
    /// create by xingbo 19/05/29
    /// </summary>
    public class KeyAndValueResult
    {
        /// <summary>
        /// key
        /// </summary>
        [JsonProperty("key")]
        public dynamic Key { get; set; }

        /// <summary>
        /// value
        /// </summary>
        [JsonProperty("value")]
        public dynamic Value { get; set; }
    }
}
