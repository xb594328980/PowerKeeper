using PowerKeeper.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Events.Office
{
    /// <summary>
    /// 组织机构编辑事件
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class OfficeUpdatedEvent : Event
    {
        public OfficeUpdatedEvent(Guid id,
       string officeName,
       string officePhone,
       string officeCode,
       int officeType,
       Guid parentId,
       string parentIds,
       int delFlag,
       string remark,
       DateTime updateDate,
       Guid updateBy) : base(id, "OfficeUpdatedEvent")
        {
            Id = id;
            OfficeName = officeName;
            OfficePhone = officePhone;
            OfficeCode = officeCode;
            OfficeType = officeType;
            ParentId = parentId;
            ParentIds = parentIds;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; protected set; }
        /// <summary>
        /// 组织机构名称
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string OfficeCode { get; protected set; }
        /// <summary>
        /// 组织机构电话
        /// </summary>
        public string OfficePhone { get; protected set; }

        /// <summary>
        /// 组织机构类型
        /// </summary>
        public int OfficeType { get; protected set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public Guid ParentId { get; protected set; }

        /// <summary>
        /// 父级id集合
        /// 格式：,ParentId,
        /// </summary>
        public string ParentIds { get; protected set; }


        /// <summary>
        /// 编辑人
        /// </summary>
        public Guid? UpdateBy { get; protected set; }


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
