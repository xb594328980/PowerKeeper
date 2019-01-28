using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Application.ViewModels
{
    /// <summary>
    /// 员工视图模型
    /// </summary>
    public class StaffViewModel
    {
        public StaffViewModel(Guid id,
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
            Guid? updateBy)
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
        public StaffViewModel()
        {

        }
        /// <summary>
        /// 员工
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string StaffName { get;  set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public int StaffType { get;  set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public Guid OfficeId { get;  set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get;  set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get;  set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get;  set; }

        /// <summary>
        /// 启用标志
        /// </summary>
        public int EnabledFlag { get;  set; }

        /// <summary>
        /// 启用登录标志
        /// </summary>
        public int LoginFlag { get;  set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid CreateBy { get;  set; }

        /// <summary>
        /// 编辑人
        /// </summary>
        public Guid? UpdateBy { get;  set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get;  set; }

        /// <summary>
        /// 编辑日期
        /// </summary>
        public DateTime? UpdateDate { get;  set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get;  set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int DelFlag { get;  set; }
    }
}
