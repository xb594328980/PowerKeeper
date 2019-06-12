using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PowerKeeper.Application.Helper;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Application.RequestModels
{
    /// <summary>
    /// 创建员工
    /// create  by xingbo 19/06/11
    /// </summary>
    public class CreateStaffRequestModel
    {

        /// <summary>
        /// 员工类型
        /// </summary>
        [Display(Name = "员工类型")]
        [Required(ErrorMessage = "{0}必填")]
        [EnumVal(typeof(StaffTypeEnum))]
        public int StaffType { get; set; }


        /// <summary>
        /// 员工昵称
        /// </summary>
        [Display(Name = "昵称")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(32, ErrorMessage = "{0}长度须在8~32范围内", MinimumLength = 8)]
        public string NickName { get; set; }

        /// <summary>
        /// 登录账户
        /// </summary>
        [Display(Name = "账户")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(32, ErrorMessage = "{0}长度须在8~32范围内", MinimumLength = 8)]
        public string Account { get; set; }

        /// <summary>
        /// 登录密码，未加密
        /// </summary>
        [Display(Name = "登录密码")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(16, ErrorMessage = "{0}长度须在8~16范围内", MinimumLength = 8)]
        public string Password { get; set; }

        /// <summary>
        /// 组织机构id
        /// </summary>
        [Display(Name = "组织机构")]
        [Required(ErrorMessage = "{0}必填")]
        public Guid OfficeId { get; set; }

        /// <summary>
        ///手机号
        /// </summary>
        [Display(Name = "手机号")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        [Required(ErrorMessage = "{0}必填")]
        [EnumVal(typeof(StaffStateEnum))]
        public int State { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(1024, ErrorMessage = "{0}长度须在0~1024范围内", MinimumLength = 0)]
        public string Remark { get; set; }

        /// <summary>
        /// 角色id列表
        /// </summary>
        [Display(Name = "角色id列表")]
        public Guid[] RoleList { get; set; }
    }
}
