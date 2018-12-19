using Christ3D.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.UoW
{
    /// <summary>
    /// 工作单元类
    /// <remarks>create by  xingbo 18/12/19</remarks>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //数据库上下文
        private readonly PowerKeeperContext _context;

        //构造函数注入
        public UnitOfWork(PowerKeeperContext context)
        {
            _context = context;
        }

        //上下文提交
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        //手动回收
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
