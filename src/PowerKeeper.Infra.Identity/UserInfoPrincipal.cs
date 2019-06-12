using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using PowerKeeper.Infra.Tool;

namespace PowerKeeper.Infra.Identity
{
    public class UserInfoPrincipal
    {

        #region 属性
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid StaffId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        ///组织机构id
        /// </summary>
        public Guid OfficeId { get; set; }
        /// <summary>
        ///组织机构名称
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int StaffType { get; set; }

        /// <summary>
        /// 员工拥有的角色id列表
        /// </summary>
        public Guid[] Roles { get; set; }
        #endregion

        #region 构造
        public UserInfoPrincipal(ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            if (claims == null || !claims.Any())
                throw new AggregateException("身份参数不存在");
            Name = claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;
            StaffId = claims.SingleOrDefault(x => x.Type == CustomClaimTypes.StaffId).Value.ToGuid();
            Account = claims.SingleOrDefault(x => x.Type == CustomClaimTypes.Account).Value;
            OfficeId = claims.SingleOrDefault(x => x.Type == CustomClaimTypes.OfficeId).Value.ToGuid();
            OfficeName = claims.SingleOrDefault(x => x.Type == CustomClaimTypes.OfficeName).Value;
            StaffType = int.Parse(claims.SingleOrDefault(x => x.Type == CustomClaimTypes.StaffType).Value);
            Roles = null; ;
        }
        public UserInfoPrincipal()
        {
        }
        #endregion
    }
}
