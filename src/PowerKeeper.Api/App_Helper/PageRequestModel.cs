using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerKeeper.Api.App_Helper
{
    /// <summary>
    /// 分页请求参数
    /// create by xingbo 
    /// </summary>
    public class PageRequestModel
    {
        /// <summary>
        /// 获取数据开始位置
        /// </summary>
        public int Start { get; set; } = 0;

        /// <summary>
        /// 获取数据长度，当为-1时则为获取全部
        /// </summary>
        public int Length { get; set; } = 20;
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortBy { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public string OrderBy
        {
            get;
            set;
        }
        /// <summary>
        /// 获取分页参数
        /// </summary>
        /// <param name="take">获取数据条目</param>
        /// <param name="skip">跳过数据量</param>
        /// <returns>是否分页，根据Length判断，-1为不分页获取全部 </returns>
        public bool PageParams(out int take, out int skip)
        {
            take = Length == -1 ? -1 : (Length > 0 ? Length : 20);
            skip = Length == -1 ? 0 : (Start > 0 ? (Start - 1) : 0);
            return Length == -1;
        }
    }
}
