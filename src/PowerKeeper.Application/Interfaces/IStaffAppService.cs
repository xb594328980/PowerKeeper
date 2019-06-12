using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Application.RequestModels;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Application.Interfaces
{
    /// <summary>
    /// 员工
    /// create by xingbo 19/06/11
    /// </summary>
    public interface IStaffAppService
    {
        /// <summary>
        /// 获取员工信息，条件不能同时为空
        /// create by xingbo 19/06/12
        /// </summary>
        /// <param name="id"></param>
        /// <param name="account"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        StaffViewModel Get(Guid? id = null, string account = null, string mobile = null, string email = null);


        /// <summary>
        /// 获取员工信息
        /// create by xingbo 19/06/12
        /// </summary>
        /// <param name="account"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="nickName"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        IList<StaffViewModel> Gets(string account = null, string mobile = null, string email = null, string nickName = null, int? take = null, int skip = 0);

        /// <summary>
        /// 创建员工
        /// create by xingbo 19/06/11
        /// </summary>
        /// <param name="request">客户请求传递参数</param>
        /// <param name="createBy">创建人</param>
        /// <param name="id">主键</param>
        /// <param name="createDateTime">创建时间</param>
        /// <param name="delFlag">删除标志</param>
        /// <returns></returns>
        Guid CreateStaff(CreateStaffRequestModel request, Guid createBy, Guid? id = null,
            DateTime? createDateTime = null,
            DelFlagEnum delFlag = DelFlagEnum.Normal);

        /// <summary>
        /// 编辑员工
        /// create by xingbo 19/06/12
        /// </summary>
        /// <param name="request">客户请求传递参数</param>
        /// <param name="updateBy">编辑人</param>
        /// <param name="updateDateTime">编辑时间</param>
        /// <returns></returns>
        void EditStaff(EditStaffRequestModel request, Guid updateBy,DateTime? updateDateTime = null);

        /// <summary>
        /// 删除员工
        /// create by xingbo 19/06/12
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDateTime"></param>
        void RemoveStaff(Guid id, Guid updateBy, DateTime? updateDateTime = null);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDateTime"></param>
        void EditStaffPassword(EditStaffPasswordRequestModel request, Guid id, Guid updateBy,
            DateTime? updateDateTime = null);
    }
}
