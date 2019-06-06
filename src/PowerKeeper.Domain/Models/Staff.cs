using PowerKeeper.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Models
{
    /// <summary>
    /// 员工领域模型
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// <remarks>update by xingbo 19/06/06</remarks>
    /// </summary>
    public class Staff : Entity
    {

        public Staff(Guid id,
            int staffType,
            string nickName,
            string account,
            string password,
            Guid officeId,
            string mobile,
            string email,
            int state,
            Guid createBy,
            DateTime createDate,
            int delFlag,
            string remark,
            DateTime? updateDate,
            Guid? updateBy)
        {
            Id = id;
            this.StaffType = staffType;
            this.NickName = nickName;
            this.Account = account;
            this.Password = password;
            this.OfficeId = officeId;
            this.Mobile = mobile;
            this.Email = email;
            this.State = state;
            this.CreateDate = createDate;
            this.CreateBy = createBy;
            this.DelFlag = delFlag;
            this.Remark = remark;
            this.UpdateDate = updateDate;
            this.UpdateBy = updateBy;
        }



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
    }
}
