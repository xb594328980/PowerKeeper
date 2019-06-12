using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Application.ViewModels;

namespace PowerKeeper.Application.ResponseModels
{
    /// <summary>
    /// 授权登录返回信息
    ///<remarks>
    /// create by xingbo 19/05/16
    /// </remarks>
    /// </summary>
    public class AuthorizedLoginResponseModel
    {
        /// <summary>
        /// 登录token
        /// <remarks>访问非匿名访问接口，需在headers中回传此值</remarks>
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public StaffViewModel StaffInfo { get; set; }
    }
}
