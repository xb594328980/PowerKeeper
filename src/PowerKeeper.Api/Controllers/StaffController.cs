using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerKeeper.Api.ViewModels;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Identity;
using PowerKeeper.Infra.Tool.Helpers;
using PowerKeeper.Infra.Tool.Maps;

namespace PowerKeeper.Api.Controllers
{
    /// <summary>
    /// 员工基础操作
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    [Route("[controller]")]
    public class StaffController : ApiController
    {
        #region 初始化
        private readonly IStaffAppService _staffAppService;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="mediator"></param>
        /// <param name="staffAppService"></param>
        public StaffController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IStaffAppService staffAppService) : base(notifications, mediator)
        {
            _staffAppService = staffAppService;
        }


        #endregion
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _staffAppService.GetAll();
            return Response(list);
        }
        /// <summary>
        /// 获取单条
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {

            var list = _staffAppService.GetById(id);
            return Response(list);
        }

        /// <summary>
        /// 新增单条
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody]CreateStaffViewModel model)
        {
            StaffViewModel staff = model.MapTo<StaffViewModel>();
            staff.Id = Guid.NewGuid();
            staff.UpdateDate = null;
            staff.UpdateBy = null;
            staff.DelFlag = (int)DelFlagEnum.Normal;
            staff.CreateBy = staff.Id;
            staff.CreateDate = DateTime.Now;
            _staffAppService.Add(staff);
            return Response(staff.Id);
        }

    }
}