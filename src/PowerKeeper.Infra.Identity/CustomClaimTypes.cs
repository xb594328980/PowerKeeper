using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Identity
{
    /// <summary>
    /// 自定义ClaimTypes
    /// <remarks>create by xingbo 18/12/28</remarks>
    /// </summary>
    public class CustomClaimTypes
    {
        //
        // 用户id
        //     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/staffId.
        public const string StaffId = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/staffId";
        //
        // 账户
        //     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/account.
        public const string Account = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/account";

        //
        // 组织机构id:
        //     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/officeid.
        public const string OfficeId = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/officeid";

        //
        // 组织机构名称:
        //     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/officename.
        public const string OfficeName = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/officename";


        //
        // 员工类型:
        //     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/stafftype.
        public const string StaffType = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/stafftype";

        //
        // 角色ids:
        //     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/roles.
        public const string Roles = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/roles";
    }
}
