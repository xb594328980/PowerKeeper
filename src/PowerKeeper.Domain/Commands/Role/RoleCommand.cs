using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Core.Commands;

namespace PowerKeeper.Domain.Commands.Role
{
    /// <summary>
    /// 角色命令
    /// create by xingbo 19/06/06
    /// </summary>
    public abstract class RoleCommand : Command
    {

        public RoleCommand()
        {

        }

        public RoleCommand(Guid id,
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
        public Guid Id { get; protected set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public int RoleType { get; protected set; }

        /// <summary>
        /// 权限范围
        /// </summary>
        public int DataScope { get; protected set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; protected set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; protected set; }


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
