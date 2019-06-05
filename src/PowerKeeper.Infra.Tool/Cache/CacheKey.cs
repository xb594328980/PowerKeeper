using System;
using System.Collections;
using System.Collections.Generic;

namespace PowerKeeper.Infra.Tool.Cache
{
    /// <summary>
    /// 描述：缓存设置键值类（在此统一设置）
    /// 时间：2016-5-5
    /// 作者：邢博
    /// </summary>
    public class CacheKey
    {
        private const string Systemstring = "Sansunt.HiCard";
        #region 成员
        /// <summary>
        /// 员工菜单缓存
        /// </summary>
        private const string MenuListForStaff = Systemstring + "MenuListForStaff_";
        /// <summary>
        /// 系统菜单缓存
        /// </summary>
        private const string MenuSystem = Systemstring + "MenuSystem_";
        /// <summary>
        /// 
        /// </summary>
        private const string ApplicationSubSystem = Systemstring + "ApplicationSubSystem";

        /// <summary>
        ///员工角色对应关系
        /// </summary>
        private const string StaffRole = Systemstring + "StaffRole";
        /// <summary>
        /// 角色菜单对应关系
        /// </summary>
        private const string RoleMenu = Systemstring + "RoleMenu";
        /// <summary>
        /// 验证码
        /// </summary>
        private const string VerificationCode = Systemstring + "VerificationCode_";

        /// <summary>
        /// 角色列表
        /// </summary>
        private const string RoleList = Systemstring + "RoleList_";
        /// <summary>
        /// 角色组织机构对应列表
        /// </summary>
        private const string RoleOfficeList = Systemstring + "RoleOfficeList_";
        /// <summary>
        /// 字典类型下的字典集合
        /// </summary>
        private const string DicList = Systemstring + "DicList_";
        /// <summary>
        /// AccessToken
        /// </summary>
        private const string AccessToken = Systemstring + "AccessToken";
        #endregion
        #region 属性
        /// <summary>
        /// 获取系统的所有菜单
        /// </summary>
        /// <returns></returns>
        public static string Menu()
        {
            return MenuSystem;
        }
        /// <summary>
        /// 用户的菜单
        /// </summary>
        /// <param name="staffId">用户id</param>
        /// <returns></returns>
        public static string MenuListByStaffId(int staffId)
        {
            return MenuListForStaff + staffId;
        }
        /// <summary>
        /// 子系统
        /// </summary>
        /// <returns></returns>
        public static string ApplicationSubSystemList()
        {
            return ApplicationSubSystem;
        }
        /// <summary>
        /// 员工与角色的对应关系
        /// </summary>
        /// <returns></returns>
        public static string StaffRoleList()
        {
            return StaffRole;
        }
        /// <summary>
        /// 获取角色菜单对应关系
        /// </summary>
        /// <returns></returns>
        public static string RoleMenuList()
        {
            return RoleMenu;
        }
        /// <summary>
        /// 精确到毫秒的时间戳
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static string GetVerificationCode(string timeStamp)
        {
            return VerificationCode + timeStamp;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public static string GetRoleList()
        {
            return RoleList;
        }
        /// <summary>
        /// 获取角色组织机构列表
        /// </summary>
        /// <returns></returns>
        public static string GetRoleOfficeList()
        {
            return RoleOfficeList;
        }
        /// <summary>
        /// 按照字典类型获取字典
        /// </summary>
        /// <param name="dicTypeCode"></param>
        /// <returns></returns>
        public static string GetDicListByDicTypeCode(string dicTypeCode)
        {
            return DicList + dicTypeCode;
        }
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken()
        {
            return AccessToken;
        }
        #endregion

    }
}
