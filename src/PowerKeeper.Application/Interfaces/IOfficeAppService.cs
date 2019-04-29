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
        /// <param name="officeViewModel"></param>
        void Add(OfficeViewModel officeViewModel);
        /// <summary>
        /// 获取全部
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// <remarks></remarks>
        /// </summary>
        IEnumerable<OfficeViewModel> GetAll();
        /// <summary>
        /// 获取单条
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// <remarks></remarks>
        /// </summary>
        OfficeViewModel GetById(Guid id);
        /// <summary>
        /// 更新
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// <remarks></remarks>
        /// </summary>
        /// <param name="officeViewModel"></param>
        void Update(OfficeViewModel officeViewModel);
        /// <summary>
        /// 删除
        /// <remarks>create by xingbo 18/12/19</remarks>
        /// </summary>
        /// <param name="officeViewModel"></param>
        void Delete(OfficeViewModel officeViewModel);
    }
}
