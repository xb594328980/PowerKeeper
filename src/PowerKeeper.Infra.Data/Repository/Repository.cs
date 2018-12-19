using Microsoft.EntityFrameworkCore;
using PowerKeeper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PowerKeeper.Infra.Data.Repository
{
    /// <summary>
    /// 仓储基类
    /// <remarks>create by xingbo 18/12/19</remarks>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        #region 构造
        public Repository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }


        #endregion

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Add(IEnumerable<TEntity> objList)
        {
            DbSet.AddRange(objList);
        }
        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(exp);
        }

        public virtual void Update(params TEntity[] objList)
        {
            for (int i = 0; i < objList.Length; i++)
                Db.Entry<TEntity>(objList[i]).State = EntityState.Modified;
            DbSet.AttachRange(objList);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
