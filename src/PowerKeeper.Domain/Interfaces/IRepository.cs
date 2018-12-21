using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PowerKeeper.Domain.Interfaces
{
    /// <summary>
    /// 定义泛型仓储接口，并继承IDisposable，显式释放资源
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="objList"></param>
        void Add(IEnumerable<TEntity> objList);
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp);
        /// <summary>
        /// 根据对象进行更新
        /// </summary>
        /// <param name="objList"></param>
        void Update(params TEntity[] objList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldNames"></param>
        void Update(TEntity entity, List<string> fieldNames = null);

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
