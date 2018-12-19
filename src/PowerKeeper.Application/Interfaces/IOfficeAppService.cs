using PowerKeeper.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Application.Interfaces
{
    /// <summary>
    /// 组织机构服务定义
    /// <remarks>create by xingbo 18/12/19</remarks>
    /// </summary>
    public interface IOfficeAppService : IDisposable
    {
        /// <summary>
        /// 新增
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// </summary>
        /// <param name="classViewModel"></param>
        void Add(OfficeViewModel classViewModel);
        /// <summary>
        /// 获取全部
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// <remarks></remarks>
        /// </summary>
        /// <param name="classViewModel"></param>
        IEnumerable<OfficeViewModel> GetAll();
        /// <summary>
        /// 获取单条
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// <remarks></remarks>
        /// </summary>
        /// <param name="classViewModel"></param>
        OfficeViewModel GetById(Guid id);
        /// <summary>
        /// 更新
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// <remarks></remarks>
        /// </summary>
        /// <param name="classViewModel"></param>
        void Update(OfficeViewModel classViewModel);
        /// <summary>
        /// 删除
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// </summary>
        /// <param name="classViewModel"></param>
        void Remove(OfficeViewModel classViewModel);
    }
}
