using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PowerKeeper.Infra.Identity
{
    /// <summary>
    /// 身份认证接口
    /// <remarks>create by xingbo 18/12/28</remarks>
    /// </summary>
    public interface IIdentity
    {
        /// <summary>
        /// 追加Claims
        /// <remarks>create by xingbo 18/12/28</remarks>
        /// </summary>
        ///  <param name="time">登录时间</param>
        /// <returns></returns>
        Claim[] AppendClaims(DateTime time);

        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="securityKey">秘钥</param>
        /// <param name="paramClaims">票据</param>
        /// <returns>token</returns>
        string GenerateToken(string securityKey, params Claim[] paramClaims);

        /// <summary>
        /// 处理身份字符串
        /// </summary>
        /// <param name="securityKey">秘钥</param>
        /// <param name="authorization">身份字符串</param>
        /// <param name="validatedToken">返回校验结果</param>
        /// <returns></returns>
        ClaimsPrincipal ProcessingAuthorization(string securityKey, string authorization, out SecurityToken validatedToken);

        /// <summary>
        /// 获取验证参数
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        TokenValidationParameters GetTokenValidationParameters(string securityKey);

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="securityKey"></param>
        void AddIdentitySetup(IServiceCollection services, string securityKey);
    }
}
