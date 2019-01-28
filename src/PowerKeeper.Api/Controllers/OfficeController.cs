using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Infra.Identity;
using PowerKeeper.Infra.Tool.Helpers;

namespace PowerKeeper.Api.Controllers
{
    /// <summary>
    /// 组织机构控制器
    /// <remarks>Create by xingbo 18/12/20</remarks>
    /// </summary>
    [Route("[controller]")]
    public class OfficeController : ApiController
    {
        private readonly IOfficeAppService _officeAppService;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="mediator"></param>
        /// <param name="officeAppService"></param>
        public OfficeController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IOfficeAppService officeAppService) : base(notifications, mediator)
        {
            _officeAppService = officeAppService;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            IdentityManager identityManager = Ioc.Create<IdentityManager>();// new Identi

            var token = identityManager.GenerateToken(new UserInfoPrincipal()
            {
                StaffId = Guid.NewGuid(),
                Name = "Name",
                Account = "Account",
                OfficeName = "OfficeName",
                OfficeId = Guid.NewGuid(),
                Roles = new Guid[] { Guid.NewGuid() },
                StaffType = 0
            });
            var list = Ioc.Create<IOfficeAppService>().GetAll();
            // var list = _officeAppService.GetAll();
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

            var list = _officeAppService.GetById(id);
            return Response(list);
        }

        /// <summary>
        /// 新增单条
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody]OfficeViewModel model)
        {
            model = new OfficeViewModel()
            {
                Id = Guid.NewGuid(),
                ParentId = Guid.NewGuid(),
                ParentIds = ",,",
                CreateBy = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                DelFlag = 0,
                OfficeCode = null,
                OfficeName = "测试",
                OfficeType = 0,
                OfficePhone = null,
                Remark = null

            };
            _officeAppService.Add(model);
            return Response(model.Id);
        }
    }
}