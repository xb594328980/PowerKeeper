using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Core.Events
{
    /// <summary>
    /// 事件模型 抽象基类，继承 INotification
    /// 也就是说，拥有中介者模式中的 发布/订阅模式
    /// <remarks>create by xingbo 18/12/17</remarks>
    /// </summary>
    public abstract class Event : INotification
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageType { get; protected set; }

        /// <summary>
        /// 聚合根id
        /// </summary>
        public Guid AggregateId { get; protected set; }
        // 时间戳
        public DateTime Timestamp { get; private set; }

        // 每一个事件都是有状态的
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
        protected Event(Guid aggregateId, string messageType, DateTime? timestamp = null) : this()
        {
            AggregateId = aggregateId;
            MessageType = messageType;
            if (timestamp.HasValue)
                Timestamp = timestamp.Value;

        }
    }
}
