using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PowerKeeper.Application.RequestModels
{
    /// <summary>
    /// 修改员工密码
    /// create by xingbo 19/06/12
    /// </summary>
    public class EditStaffPasswordRequestModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
        public Guid? Id { get; set; }

        /// <summary>
        /// 原登录密码，未加密
        /// </summary>
        [Display(Name = "原登录密码")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(16, ErrorMessage = "{0}长度须在8~16范围内", MinimumLength = 8)]
        public string Password { get; set; }

        /// <summary>
        /// 新登录密码，未加密
        /// </summary>
        [Display(Name = "新登录密码")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(16, ErrorMessage = "{0}长度须在8~16范围内", MinimumLength = 8)]
        public string NewPassword { get; set; }
    }
}
