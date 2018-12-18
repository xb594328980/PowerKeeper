using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Core.Events
{
    /// <summary>
    /// 抽象类Message，用来获取我们事件执行过程中的类名
    /// 然后并且添加聚合根
    /// <remarks>create by xingbo 18/12/17</remarks>
    /// </summary>
    public abstract class Message : IRequest
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageType { get; protected set; }
        /// <summary>
        /// 聚合根
        /// </summary>
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
