using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Core.Commands;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 员工基础命令模型
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public abstract class StaffCommand : Command
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Id { get; protected set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public int StaffType { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public Guid OfficeId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get;  set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 启用标志
        /// </summary>
        public int EnabledFlag { get; set; }

        /// <summary>
        /// 启用登录标志
        /// </summary>
        public int LoginFlag { get; set; }
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
