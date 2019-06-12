using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerKeeper.Domain.Core.Commands;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 员工基础命令
    /// create by xingbo 19/06/06
    /// </summary>
    public abstract class StaffCommand : Command
    {
        public StaffCommand()
        {

        }
        public StaffCommand(Guid id,
           int staffType,
           Guid officeId,
           string nickName,
           string account,
           string password,
           int state,
           Guid createBy,
           Guid[] roleList,
           string mobile = null,
           string email = null,
           DateTime? createDate = null,
           string remark = null,
           DateTime? updateDate = null,
           Guid? updateBy = null,
        int delFlag = (int)DelFlagEnum.Normal)
        {
            RoleList = roleList?.Distinct().ToArray();
            Id = id;
            this.StaffType = staffType;
            this.NickName = nickName;
            this.Account = account;
            this.Password = password;
            this.OfficeId = officeId;
            this.Mobile = mobile;
            this.Email = email;
            this.State = state;
            this.CreateDate = createDate ?? DateTime.Now;
            this.CreateBy = createBy;
            this.Remark = remark;
            this.UpdateDate = updateDate;
            this.UpdateBy = updateBy;
            this.DelFlag = delFlag;
        }


        public Guid Id { get; set; }
        /// <summary>
        /// 员工类型
        /// </summary>
        public int StaffType { get; set; }


        /// <summary>
        /// 员工昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 登录账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 组织机构id
        /// </summary>
        public Guid OfficeId { get; set; }

        /// <summary>
        ///手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

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

        /// <summary>
        /// 角色id列表
        /// </summary>
        public Guid[] RoleList { get; set; }
    }
}
