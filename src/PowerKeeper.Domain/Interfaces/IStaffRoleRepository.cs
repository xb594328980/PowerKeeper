using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Domain.Interfaces
{
    /// <summary>
    /// 员工角色对应表仓储接口
    /// create by xingbo 19/06/10
    /// </summary>
    public interface IStaffRoleRepository : IRepository<StaffRole>
    {
        /// <summary>
        /// 按照员工id删除员工与角色关系
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        int RemovebyStaffId(Guid staffId);

        /// <summary>
        /// 按照员工id删除员工与角色关系，并增加对应角色
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        int RemoveAndInsert(Guid staffId, params Guid[] roleIds);
    }
}
