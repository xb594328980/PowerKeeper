using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Events.Office;
using System.Threading;
using System.Threading.Tasks;

namespace PowerKeeper.Domain.EventHandlers
{
    /// <summary>
    /// 组织机构事件处理
    /// </summary>
    public class OfficeEventHandler :
        INotificationHandler<OfficeCreatedEvent>,
        INotificationHandler<OfficeUpdatedEvent>,
        INotificationHandler<OfficeDeletedEvent>
    {
        public Task Handle(OfficeCreatedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(OfficeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OfficeDeletedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
