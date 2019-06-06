using PowerKeeper.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Models
{
    /// <summary>
    /// 资源(菜单、按钮等资源)领域模型
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class Resource : Entity
    {

        public Resource(Guid id,
            Guid parentId,
            string parentIds,
            int resourceType,
            string resourceName,
            string resourceCode,
            string showName,
            string resourceUrl,
            string interfaceUrl,
            string resourceIcon,
            int isShow,
            int isEnable,

            Guid createBy,
            DateTime createDate,
            int delFlag,
            string remark,
            DateTime? updateDate,
            Guid? updateBy)
        {
            Id = id;
            ResourceType = resourceType;
            ResourceName = resourceName;
            ResourceCode = resourceCode;
            ShowName = showName;
            ResourceUrl = resourceUrl;
            InterfaceUrl = interfaceUrl;
            ResourceIcon = resourceIcon;
            IsShow = isShow;
            IsEnable = isEnable;
            ParentId = parentId;
            ParentIds = parentIds;
            CreateDate = createDate;
            CreateBy = createBy;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }

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
        /// 资源类型
        /// </summary>
        public int ResourceType { get; set; }


        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// 资源编码
        /// </summary>
        public string ResourceCode { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName { get; set; }



        /// <summary>
        ///资源链接
        /// </summary>
        public string ResourceUrl { get; set; }

        /// <summary>
        /// 接口链接
        /// </summary>
        public string InterfaceUrl { get; set; }

        /// <summary>
        /// 资源按钮
        /// </summary>
        public string ResourceIcon { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsShow { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsEnable { get; set; }

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
