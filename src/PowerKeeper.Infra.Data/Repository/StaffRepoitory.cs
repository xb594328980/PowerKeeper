using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.Repository
{
    /// <summary>
    /// 员工仓储
    /// create by xingbo 29/06/06
    /// </summary>
    public class StaffRepoitory : Repository<Staff>, IStaffRepository
    {
        public StaffRepoitory(PowerKeeperContext db) : base(db)
        {

        }
    }
}
