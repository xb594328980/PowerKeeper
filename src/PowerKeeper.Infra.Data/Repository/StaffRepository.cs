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
    /// 员工仓储
    /// <remarks>create by xingbo 19/1/3</remarks>
    /// </summary>
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(PowerKeeperContext context) : base(context)
        {
        }
    }
}
