using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerKeeper.Domain.Events.Office;
using PowerKeeper.Domain.Events.Staff;

namespace PowerKeeper.Domain.EventHandlers
{
    /// <summary>
    /// 员工事件处理
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class StaffEventHandler :
                        INotificationHandler<StaffCreatedEvent>,
        INotificationHandler<StaffUpdatedEvent>,
        INotificationHandler<StaffDeletedEvent>
    {
        public Task Handle(StaffCreatedEvent notification, CancellationToken cancellationToken)
        {

            if (!string.IsNullOrWhiteSpace(notification.Email))
            {
                //发送注册成功邮件

            }
            return Task.CompletedTask;
        }

        public Task Handle(StaffUpdatedEvent notification, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(notification.Email))
            {
                //发送编辑成功邮件

            }
            //发送编辑成功短信或邮件
            return Task.CompletedTask;
        }

        public Task Handle(StaffDeletedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
