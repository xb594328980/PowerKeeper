using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Events.Office;
using System.Threading;
using System.Threading.Tasks;

namespace PowerKeeper.Domain.EventHandlers
{
    public class OfficeEventHandler :
        INotificationHandler<OfficeCreatedEvent>,
        INotificationHandler<OfficeUpdatedEvent>,
        INotificationHandler<OfficeRemovedEvent>
    {
        public Task Handle(OfficeCreatedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(OfficeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OfficeRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
