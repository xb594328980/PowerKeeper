using PowerKeeper.Domain.Core.Events;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christ3D.Infrastruct.Data.Repository
{
    /// <summary>
    /// 事件仓储数据库仓储实现类
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class EventStoreRepository : IEventStoreRepository
    {
        // 注入事件存储数据库上下文
        private readonly SQLEventStoreContext _context;

        public EventStoreRepository(SQLEventStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据聚合id 获取全部的事件
        /// 这个聚合是指领域模型的聚合根模型
        /// </summary>
        /// <param name="aggregateId"> 聚合根id 比如：订单模型id</param>
        /// <returns></returns>
        public IList<EventStore> All(Guid aggregateId)
        {
            return _context.EventStore.Where(e => e.AggregateId == aggregateId).ToList();
        }

        /// <summary>
        /// 将命令事件持久化
        /// </summary>
        /// <param name="theEvent"></param>
        public void Store(EventStore theEvent)
        {
            _context.EventStore.Add(theEvent);
            _context.SaveChanges();
        }

        /// <summary>
        /// 手动回收
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
