using PowerKeeper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Interfaces
{
    /// <summary>
    /// 员工仓储接口
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public interface IStaffRepository : IRepository<Staff>
    {
        /// <summary>
        /// 获取单条数据,条件不能同时为空
        /// create by xingbo 19/06/12
        /// </summary>
        /// <param name="id"></param>
        /// <param name="account"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Staff Get(Guid? id = null, string account = null, string mobile = null, string email = null);

    }
}
