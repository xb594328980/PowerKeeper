using PowerKeeper.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Models
{
    /// <summary>
    /// 组织机构领域模型
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class Office : Entity
    {
        /// <summary>
        /// 组织机构名称
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string OfficeCode { get; set; }
        /// <summary>
        /// 组织机构电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 组织机构类型
        /// </summary>
        public int OfficeType { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 父级id集合
        /// 格式：,ParentId,
        /// </summary>
        public string ParentIds { get; set; }


    }
}
