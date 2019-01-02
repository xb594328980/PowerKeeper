using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

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
//            UserId = int.Parse(claims.Where(x=>x.Type== ClaimTypes.NameIdentifier));
//            StaffName = claims[1];
//            UserAccount = claims[2];
//            OfficeId = claims[3].StringToList('|').ToArray();
//            OfficeName = claims[4].StringToStringList('|').ToArray();
//            StaffType = int.Parse(list[5]);
//            RoleList = claims[6].StringToList('|').ToArray(); ;
        }
        public UserInfoPrincipal()
        {
        }
        #endregion
    }
}
