using PowerKeeper.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Models
{
    /// <summary>
    /// 角色领域模型
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class Role : Entity
    {






        public Role(Guid id,
            int roleType,
            int dataScope,
            string roleName,
            string roleCode,
            int isEnable,
            Guid createBy,
            DateTime createDate,
            int delFlag,
            string remark,
            DateTime? updateDate,
            Guid? updateBy)
        {
            Id = id;
            this.RoleType = roleType;
            this.DataScope = dataScope;
            this.RoleName = roleName;
            this.RoleCode = roleCode;
            this.IsEnable = isEnable;
            this.CreateDate = createDate;
            this.CreateBy = createBy;
            this.DelFlag = delFlag;
            this.Remark = remark;
            this.UpdateDate = updateDate;
            this.UpdateBy = updateBy;
        }

        /// <summary>
        /// 角色类型
        /// </summary>
        public int RoleType { get; set; }

        /// <summary>
        /// 权限范围
        /// </summary>
        public int DataScope { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }


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
