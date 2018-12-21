using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.Repository
{
    /// <summary>
    /// 仓储基类
    /// <remarks>create by xingbo 18/12/19</remarks>
    /// </summary>
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(PowerKeeperContext db) : base(db)
        {

        }
    }
}
