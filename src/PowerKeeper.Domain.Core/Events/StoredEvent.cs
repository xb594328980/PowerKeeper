using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Core.Events
{
    /// <summary>
    /// 领域事件存储
    /// <remarks>create by xingbo 18/12/17</remarks>
    /// </summary>
    public class StoredEvent : Event
    {
        /// <summary>
        /// 构造方式实例化
        /// </summary>
        /// <param name="theEvent"></param>
        /// <param name="data"></param>
        /// <param name="user"></param>
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        // 为了EFCore能正确CodeFirst
        protected StoredEvent() { }
        // 事件存储Id
        public Guid Id { get; private set; }
        // 存储的数据
        public string Data { get; private set; }

        // 用户信息
        public string User { get; private set; }
    }
}
