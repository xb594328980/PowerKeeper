using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Application.ViewModels;

namespace PowerKeeper.Application.Interfaces
{
    /// <summary>
    /// 员工服务定义
    /// <remarks>create by xingbo 19/1/4</remarks>
    /// </summary>
    public interface IStaffAppService : IDisposable
    {
        /// <summary>
        /// 新增
        /// <remarks>create by xingbo 19/1/4</remarks>
        /// </summary>
        /// <param name="staffViewModel"></param>
        void Add(StaffViewModel staffViewModel);
        /// <summary>
        /// 获取全部
        /// <remarks>create by xingbo 19/1/4</remarks>
        /// <remarks></remarks>
        /// </summary>
        IEnumerable<StaffViewModel> GetAll();
        /// <summary>
        /// 获取单条
        /// <remarks>create by xingbo 19/1/4</remarks>
        /// <remarks></remarks>
        /// </summary>
        StaffViewModel GetById(Guid id);
        /// <summary>
        /// 更新
        /// <remarks>create by xingbo 19/1/4</remarks>
        /// <remarks></remarks>
        /// </summary>
        /// <param name="staffViewModel"></param>
        void Update(StaffViewModel staffViewModel);
        /// <summary>
        /// 删除
        /// <remarks>create by xingbo 19/1/4</remarks>
        /// </summary>
        /// <param name="staffViewModel"></param>
        void Delete(StaffViewModel staffViewModel);
    }
}
