using FluentValidation;
using PowerKeeper.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Infra.Tool.Helpers;

namespace PowerKeeper.Domain.Validations
{
    /// <summary>
    /// 基础验证辅助
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    /// <typeparam name="T">命令模型</typeparam>
    public abstract  class BaseValidation<T> : AbstractValidator<T> where T : Command
    {
        /// <summary>
        /// 验证电话
        /// <remarks>create by xingbo 18/12/20</remarks>
        /// </summary>
        /// <param name="str_telephone"></param>
        /// <returns></returns>
        protected bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        /// <summary>
        /// 验证手机号码
        /// <remarks>create by xingbo 18/12/20</remarks>
        /// </summary>
        /// <param name="str_mobile"></param>
        /// <returns></returns>
        protected bool IsMobile(string str_mobile)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_mobile, @"^[1]+[3,4,5,7,8,9]+\d{9}");
        }

        /// <summary>
        /// 验证身份证号
        /// <remarks>create by xingbo 18/12/20</remarks>
        /// </summary>
        /// <param name="str_idcard">身份证</param>
        /// <returns></returns>
        protected bool IsIDcard(string str_idcard)
        {
            if (str_idcard.Length == 15)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}[0-9Xx]$");
            }
            else if (str_idcard.Length == 18)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$");

            }
            return false;
        }


        /// <summary>
        ///  验证邮编
        /// <remarks>create by xingbo 18/12/20</remarks>
        /// </summary>
        /// <param name="str_postalcode"></param>
        /// <returns></returns>
        protected bool IsPostalcode(string str_postalcode)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
    }
}
