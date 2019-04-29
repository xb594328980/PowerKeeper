using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Core.Events;

namespace PowerKeeper.Domain.Events.Staff
{
    /// <summary>
    /// 员工更新事件
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class StaffCreatedEvent : Event
    {
        public StaffCreatedEvent(Models.Staff staff)
            : this(staff.Id,
                staff.StaffName,
                staff.StaffType,
                staff.OfficeId,
                staff.Account,
                staff.Mobile,
                staff.Email,
                staff.EnabledFlag,
                staff.LoginFlag,
                staff.CreateBy,
                staff.CreateDate,
                staff.DelFlag,
                staff.Remark,
                staff.UpdateDate,
                staff.UpdateBy
                )
        {
        }
        public StaffCreatedEvent(Guid id,
         string staffName,
         int staffType,
         Guid officeId,
         string account,
         string mobile,
         string email,
         int enabledFlag,
         int loginFlag,
         Guid createBy,
         DateTime createDate,
         int delFlag,
         string remark,
         DateTime? updateDate,
         Guid? updateBy) : base(id, "StaffCreatedEvent")
        {
            Id = id;
            StaffName = staffName;
            StaffType = staffType;
            OfficeId = officeId;
            Account = account;
            Mobile = mobile;
            Email = email;
            EnabledFlag = enabledFlag;
            LoginFlag = loginFlag;
            CreateDate = createDate;
            CreateBy = createBy;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        public StaffCreatedEvent()
        {

        }
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// 员工名称
        /// </summary>
        public string StaffName { get; protected set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public int StaffType { get; protected set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public Guid OfficeId { get; protected set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; protected set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; protected set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; protected set; }

        /// <summary>
        /// 启用标志
        /// </summary>
        public int EnabledFlag { get; protected set; }

        /// <summary>
        /// 启用登录标志
        /// </summary>
        public int LoginFlag { get; protected set; }
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
