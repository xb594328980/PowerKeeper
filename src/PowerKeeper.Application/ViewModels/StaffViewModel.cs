using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Tool;
using Enum = PowerKeeper.Infra.Tool.Helpers.Enum;

namespace PowerKeeper.Application.ViewModels
{
    /// <summary>
    /// 员工视图model
    /// create by xingbo 19/06/11
    /// </summary>
    public class StaffViewModel
    {

        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public int StaffType { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public string StaffTypeStr
        {
            get { return Enum.GetDescription(typeof(StaffTypeEnum), StaffType); }
        }

        /// <summary>
        /// 员工昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 登录账户
        /// </summary>
        public string Account { get; set; }


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
        /// 状态
        /// </summary>
        public string StateStr
        {
            get { return Enum.GetDescription(typeof(StaffStateEnum), State); }
        }

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
        /// 创建日期
        /// </summary>
        public string CreateDateStr
        {
            get { return CreateDate.ToDateTimeString(); }
        }

        /// <summary>
        /// 编辑日期
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 编辑日期
        /// </summary>
        public string UpdateDateStr
        {
            get { return UpdateDate?.ToDateTimeString(); }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
