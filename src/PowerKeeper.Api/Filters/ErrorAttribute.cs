using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PowerKeeper.Api.App_Helper;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Identity;


namespace PowerKeeper.Api.Filters
{
    /// <summary>
    ///
    /// </summary>
    public class ErrorAttribute : ExceptionFilterAttribute
    {
        private readonly IdentityManager _identityManager;
        public ErrorAttribute(IdentityManager identityManager)
        {
            _identityManager = identityManager;

        }

        public override void OnException(ExceptionContext filterContext)
        {
            //获取异常信息，入库保存
            Exception error = filterContext.Exception;
            string message = error.Message;//错误信息
            string url = filterContext.HttpContext.Request.Path;//错误发生地址
            string ip = GetRealIp(filterContext);
            filterContext.ExceptionHandled = true;
            string str = "";
            if (_identityManager.Logined())
            {
                var user = _identityManager.UserInfo;
                str = string.Format("▷时间：{2}◆「{3}」◆「{0}（{1}）」◆操作地址：{4}\n◆错误信息:{5}◁", user.Account, user.StaffId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ip, url, message);
            }
            else
            {
                str = string.Format("▷时间：{0}◆「{1}」◆操作地址：{2}\n◆错误信息:{3}◁", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ip, url, message);
            }
            filterContext.Result = new AjaxResult<object>(ErrorCodeEnum.SystemException, str);
            filterContext.ExceptionHandled = true;
        }

        /// <summary>
        /// 获取客户端ip地址
        /// </summary>
        /// <returns></returns>
        public string GetRealIp(ExceptionContext filterContext)
        {
            string ip = filterContext.HttpContext.Request.Headers["X-Real-IP"];
            if (string.IsNullOrEmpty(ip))
                ip = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
    }
}