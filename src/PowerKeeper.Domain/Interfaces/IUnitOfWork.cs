using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Interfaces
{
    /// <summary>
    /// 工作单元接口
    ///<remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 是否提交成功
        /// <remarks>create by xingbo 18/12/18</remarks>
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}
