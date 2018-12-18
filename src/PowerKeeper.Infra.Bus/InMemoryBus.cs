using MediatR;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Commands;
using PowerKeeper.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerKeeper.Infra.Bus
{
    /// <summary>
    /// 一个密封类，实现我们的中介内存总线
    /// </summary>
    public sealed class InMemoryBus : IMediatorHandler
    {
        //构造函数注入
        private readonly IMediator _mediator;
        private readonly IEventStoreService _eventStoreService;

        public InMemoryBus(IMediator mediator, IEventStoreService eventStoreService)
        {
            _mediator = mediator;
            _eventStoreService = eventStoreService;
        }

        /// <summary>
        /// 实现我们在IMediatorHandler中定义的接口
        /// 没有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            //这个是正确的
            return _mediator.Send(command);//请注意 入参 的类型
        }
        /// <summary>
        /// 引发事件的实现方法
        /// </summary>
        /// <typeparam name="T">泛型 继承 Event：INotification</typeparam>
        /// <param name="event">事件模型，比如StudentRegisteredEvent</param>
        /// <returns></returns>
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            // 除了领域通知以外的事件都保存下来
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStoreService?.Save(@event);
            // MediatR中介者模式中的第二种方法，发布/订阅模式
            return _mediator.Publish(@event);
        }


    }
}
