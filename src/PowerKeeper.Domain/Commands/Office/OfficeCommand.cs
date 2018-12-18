using PowerKeeper.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Commands.Office
{
    /// <summary>
    /// 组织机构命令基础
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public abstract class OfficeCommand : Command
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Id { get; protected set; }

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

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid CreateBy { get; protected set; }

        /// <summary>
        /// 编辑人
        /// </summary>
        public Guid? UpdateBy { get; protected set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; protected set; }

        /// <summary>
        /// 编辑日期
        /// </summary>
        public DateTime? UpdateDate { get; protected set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; protected set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int DelFlag { get; protected set; }



    }
}
