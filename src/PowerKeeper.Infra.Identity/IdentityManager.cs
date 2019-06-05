
using Microsoft.IdentityModel.Tokens;
using PowerKeeper.Infra.Tool.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PowerKeeper.Infra.Identity
{
    /// <summary>
    /// 身份管理器
    /// <remarks>create by xingbo 18/12/28</remarks>
    /// </summary>
    public class IdentityManager
    {
        /// <summary>
        ///参数构造
        /// </summary>
        private Microsoft.AspNetCore.Http.HttpContext _context;
        /// <summary>
        /// 身份认证
        /// </summary>
        private IIdentity _identity;


        /// <summary>
        /// jwt秘钥的签名
        /// </summary>
        public static string SecurityKey { get { return "powerkeeper_webkpi"; } }
        /// <summary>
        /// 带参数实例化
        /// </summary>
        /// <param name="context"></param>
        /// <param name="identity"></param>
        public IdentityManager(Microsoft.AspNetCore.Http.HttpContext context, IIdentity identity)
        {
            _context = context;
            _identity = identity;
        }


        public IdentityManager()
        {
            _identity = Ioc.Create<IIdentity>();
            _context = Ioc.Create<IHttpContextAccessor>().HttpContext;

        }

        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public bool Logined()
        {
            if (_context == null)
                return false;
            try
            {
                string authorizationStr = _context.Request.Headers["Authorization"];
                SecurityToken validatedToken = null;
                var result = _identity.ProcessingAuthorization(SecurityKey, authorizationStr, out validatedToken);
                if (result == null || !result.Claims.Any())
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 生成token
        /// <remarks>create by xingbo 18/12/29</remarks>
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="loginTime">登录时间</param>
        /// <returns></returns>
        public string GenerateToken(UserInfoPrincipal userInfo, DateTime? loginTime = null)
        {
            var claims = GenerateClaims(userInfo, loginTime ?? DateTime.Now);
            return _identity.GenerateToken(SecurityKey, claims);
        }

        /// <summary>
        /// 生成Claims
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="loginTime">登录时间</param>
        /// <returns></returns>
        private Claim[] GenerateClaims(UserInfoPrincipal userInfo, DateTime loginTime)
        {
            var claims = new List<Claim>()
            {
                new Claim(CustomClaimTypes.StaffId, userInfo.StaffId.ToString()),
                new Claim(CustomClaimTypes.Account, userInfo.Account),
                new Claim(ClaimTypes.Name, userInfo.Name),
                new Claim(CustomClaimTypes.StaffType, userInfo.StaffType.ToString()),
                new Claim(CustomClaimTypes.Roles, Json.ToJson(userInfo.Roles)),
                new Claim(CustomClaimTypes.OfficeName, userInfo.OfficeName),
                new Claim(CustomClaimTypes.OfficeId, userInfo.OfficeName),

            };
            claims.AddRange(_identity.AppendClaims(loginTime));//追加身份自有Claims
            return claims.ToArray();
        }

        /// <summary>
        /// 获取客户端ip地址
        /// </summary>
        /// <returns></returns>
        public string GetRealIp()
        {
            string ip = _context.Request.Headers["X-Real-IP"];
            if (string.IsNullOrEmpty(ip))
                ip = _context.Connection.RemoteIpAddress.ToString();
            return ip;
        }

        /// <summary>
        /// 获取设置参数
        /// </summary>
        public TokenValidationParameters GetTokenValidationParameters()
        {

            return _identity.GetTokenValidationParameters(SecurityKey);
        }

        public void AddIdentitySetup(IServiceCollection services)
        {
            _identity.AddIdentitySetup(services, SecurityKey);
        }

        /// <summary>
        /// 获取身份信息
        /// </summary>
        /// <returns></returns>
        public UserInfoPrincipal UserInfo
        {
            get
            {
                if (_context == null)
                    throw new Exception("未登录");
                string authorizationStr = _context.Request.Headers["Authorization"];
                SecurityToken validatedToken = null;
                var result = _identity.ProcessingAuthorization(SecurityKey, authorizationStr, out validatedToken);
                if (result == null || !result.Claims.Any())
                    throw new Exception("未登录");
                return new UserInfoPrincipal(result);
            }
        }
    }
}
