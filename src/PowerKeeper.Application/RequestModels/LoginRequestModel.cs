using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PowerKeeper.Application.RequestModels
{
    /// <summary>
    /// 登录参数
    /// create by xingbo 19/06/12
    /// </summary>
    public class LoginRequestModel
    {

        /// <summary>
        /// 登录账户
        /// </summary>
        [Display(Name = "账户")]
        [Required(ErrorMessage = "{0}必填")]
        public string Account { get; set; }

        /// <summary>
        /// 登录密码，未加密
        /// </summary>
        [Display(Name = "登录密码")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(16, ErrorMessage = "{0}长度须在8~16范围内", MinimumLength = 8)]
        public string Password { get; set; }


      


    }
}
