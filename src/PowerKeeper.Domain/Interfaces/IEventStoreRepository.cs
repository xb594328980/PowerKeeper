using PowerKeeper.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Interfaces
{
    /// <summary>
    /// 事件存储仓储接口
    /// 继承IDisposable ，可手动回收
    /// <remarks>create  by xingbo 18/12/20 </remarks>
    /// </summary>
    public interface IEventStoreRepository : IDisposable
    {
        void Store(EventStore theEvent);
        IList<EventStore> All(Guid aggregateId);
    }
}
