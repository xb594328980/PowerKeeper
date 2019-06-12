using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.Repository
{
    /// <summary>
    /// 员工角色对应表仓储
    /// create by xingbo 19/06/10
    /// </summary>
    public class StaffRoleRepository : Repository<StaffRole>, IStaffRoleRepository
    {
        public StaffRoleRepository(PowerKeeperContext context) : base(context)
        {
        }

        public int RemovebyStaffId(Guid staffId)
        {
            return Db.Database.ExecuteSqlCommand($"delete from sys_staff_role where staff_id='{staffId}'");
        }

        public int RemoveAndInsert(Guid staffId, params Guid[] roleIds)
        {
            StringBuilder strsql = new StringBuilder($"delete from sys_staff_role where staff_id='{staffId}';");
            foreach (var roleId in roleIds)
                strsql.AppendFormat("INSERT INTO `sys_staff_role` VALUES ('{0}', '{1}');", staffId, roleId);
            return Db.Database.ExecuteSqlCommand(strsql.ToString());
        }
    }
}
