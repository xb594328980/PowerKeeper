using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PowerKeeper.Api.App_Helper;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Identity;


namespace PowerKeeper.Api.Filters
{
    /// <summary>
    /// 身份验证
    /// <remarks>
    /// create by xingbo 19/05/16
    /// </remarks>
    /// </summary>
    public class AuthAttribute : ActionFilterAttribute
    {
        //        private Lazy<IRoleMenuBLL> _rolemenubll;
        //        private Lazy<IMenuBLL> _menubll;
        private readonly IdentityManager _identityManager;
        /// <summary>
        /// 构造函数用于接收依赖项
        /// </summary>
        /// <param name="identityManager"></param>
        public AuthAttribute(IdentityManager identityManager)
        {
            _identityManager = identityManager;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_identityManager.Logined())
            {
                context.Result = new AjaxResult<object>(ErrorCodeEnum.NoLogin, "登录失效，请重新登录");
            }
            base.OnActionExecuting(context);
        }


    }
}
