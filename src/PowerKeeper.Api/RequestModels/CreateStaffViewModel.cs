using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerKeeper.Api.ViewModels
{
    /// <summary>
    /// 创建用户model
    /// </summary>
    public class CreateStaffViewModel
    {
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
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
