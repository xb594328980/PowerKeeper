using Christ3D.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Commands;
using PowerKeeper.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类，提供公共方法和接口数据
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class CommandHandler
    {
        // 注入工作单元
        private readonly IUnitOfWork _uow;
        // 注入中介处理接口
        protected readonly IMediatorHandler _bus;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus)
        {
            _uow = uow;
            _bus = bus;
        }

        /// <summary>
        /// 工作单元提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
        /// <summary>
        ///将领域命令中的验证错误信息收集
        /// </summary>
        /// <param name="message"></param>
        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
        }
    }
}
