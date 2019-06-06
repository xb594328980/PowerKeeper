using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerKeeper.Api.App_Helper
{
    /// <summary>
    /// 分页查询参数
    /// <remarks>
    /// create by xingbo 19/05/16
    /// </remarks>
    /// </summary>
    public class QueryParameter
    {
        public QueryParameter()
        {
            _SortBy = "asc";
        }
        /// <summary>
        /// 第一条数据的起始位置，比如0代表第一条数据 
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 告诉服务器每页显示的条数 默认10条
        /// </summary>
        public int Length
        {
            get { return _Length == 0 ? 10 : _Length; }
            set { _Length = value; }
        }
        /// <summary>
        /// 长度
        /// </summary>
        private int _Length;

        /// <summary>
        /// 排序字段
        /// <remarks>
        /// create by xingbo 18/07/13
        /// </remarks>
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 升序、降序
        /// <remarks>
        /// create by xingbo 18/07/13
        /// </remarks>
        /// </summary>

        public string SortBy
        {
            set { _SortBy = value; }
            get
            {
                return string.IsNullOrWhiteSpace(_SortBy) ? "desc" : (_SortBy.ToLower().Equals("asc") ? "asc" : "desc");
            }
        }

        private string _SortBy;

    }
}