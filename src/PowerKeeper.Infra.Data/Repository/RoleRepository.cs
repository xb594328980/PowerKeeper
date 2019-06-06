using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.Repository
{
    /// <summary>
    /// 角色仓储
    /// create by xingbo 19/06/06
    /// </summary>
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(PowerKeeperContext db) : base(db)
        {

        }
    }
}
