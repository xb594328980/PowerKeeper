using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Core.Commands;

namespace PowerKeeper.Domain.Commands.Resource
{
    /// <summary>
    /// 资源基础命令
    /// create by xingbo 19/06/06
    /// </summary>
    public abstract class ResourceCommand : Command
    {
        public ResourceCommand()
        {
            
        }
        public ResourceCommand(Guid id,
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
        public Guid Id { get; protected set; }
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
        /// 资源类型
        /// </summary>
        public int ResourceType { get; protected set; }


        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; protected set; }

        /// <summary>
        /// 资源编码
        /// </summary>
        public string ResourceCode { get; protected set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName { get; protected set; }



        /// <summary>
        ///资源链接
        /// </summary>
        public string ResourceUrl { get; protected set; }

        /// <summary>
        /// 接口链接
        /// </summary>
        public string InterfaceUrl { get; protected set; }

        /// <summary>
        /// 资源按钮
        /// </summary>
        public string ResourceIcon { get; protected set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsShow { get; protected set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsEnable { get; protected set; }

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
