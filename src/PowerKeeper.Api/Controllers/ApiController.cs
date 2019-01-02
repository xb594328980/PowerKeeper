﻿
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace PowerKeeper.Api.Controllers
{
    /// <summary>
    /// 父级控制器
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="mediator"></param>
        protected ApiController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }
        /// <summary>
        /// 获取提醒
        /// </summary>
        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        /// <summary>
        /// 是否有提醒
        /// </summary>
        /// <returns></returns>
        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="result">结果</param>
        /// <returns></returns>
        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        /// <summary>
        /// 把验证错误引发错误通知
        /// </summary>
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }
        /// <summary>
        /// 发布错误通知
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        /// <summary>
        /// 把身份验证错误引发错误通知
        /// </summary>
        /// <param name="result"></param>
        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }
}