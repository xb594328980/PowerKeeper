using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Application.ViewModels
{
    public class OfficeViewModel
    {
        public OfficeViewModel(Guid id,
         string officeName,
         string officePhone,
         string officeCode,
         int officeType,
         Guid parentId,
         string parentIds,
         Guid createBy,
         DateTime createDate,
         int delFlag,
         string remark,
         DateTime? updateDate,
         Guid? updateBy)
        {
            Id = id;
            OfficeName = officeName;
            OfficePhone = officePhone;
            OfficeCode = officeCode;
            OfficeType = officeType;
            ParentId = parentId;
            ParentIds = parentIds;
            CreateDate = createDate;
            CreateBy = createBy;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }

        public OfficeViewModel()
        {

        }
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }
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
        public Guid CreateBy { get; set; }

        /// <summary>
        /// 编辑人
        /// </summary>
        public Guid? UpdateBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 编辑日期
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int DelFlag { get; set; }
    }
}
