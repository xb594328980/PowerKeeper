using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerKeeper.Api.App_Helper;
using PowerKeeper.Api.Filters;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Application.RequestModels;
using PowerKeeper.Application.ResponseModels;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Infra.Identity;

namespace PowerKeeper.Api.Controllers
{

    /// <summary>
    /// 员工
    /// create by xingbo 19/06/11
    /// </summary>
    public class StaffController : ApiController
    {
        #region MyRegion


        private readonly IStaffAppService _staffAppService;
        private readonly IdentityManager _identityManager;


        public StaffController(INotificationHandler<DomainNotification> notifications,
            IStaffAppService staffAppService,
            IdentityManager identityManager,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _identityManager = identityManager;
            _staffAppService = staffAppService;
        }
        #endregion

        /// <summary>
        ///创建员工
        /// create by xingbo 19/05/28
        /// </summary>
        /// <remarks>
        /// Staff_Post_CreateStaff api/staff
        /// 以json字符串的形式提交
        /// </remarks>
        /// <param name="request">请求实体</param>
        /// <returns>Returns the AjaxBackData</returns>
        /// <response code="200">Returns the data</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ServiceFilter(typeof(AuthAttribute))]
        public AjaxResult<Guid> CreateStaff([FromBody]CreateStaffRequestModel request)
        {
            #region 验证提交数据是否有误
            if (!ModelState.IsValid)
                foreach (var item in ModelState.Values)
                    foreach (var errordetails in item.Errors)
                        NotifyError("", errordetails.ErrorMessage);
            #endregion
            var user = _identityManager.UserInfo;
            var id = _staffAppService.CreateStaff(request, user.StaffId);
            return Response(id);
        }

        /// <summary>
        ///编辑员工
        /// create by xingbo 19/06/12
        /// </summary>
        /// <remarks>
        /// Staff_Put_EditStaff api/staff
        /// 以json字符串的形式提交
        /// </remarks>
        /// <param name="request">请求实体</param>
        /// <returns>Returns the AjaxBackData</returns>
        /// <response code="200">Returns the data</response>
        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ServiceFilter(typeof(AuthAttribute))]
        public AjaxResult<string> EditStaff([FromBody]EditStaffRequestModel request)
        {
            #region 验证提交数据是否有误
            if (!ModelState.IsValid)
                foreach (var item in ModelState.Values)
                    foreach (var errordetails in item.Errors)
                        NotifyError("", errordetails.ErrorMessage);
            #endregion
            var user = _identityManager.UserInfo;
            _staffAppService.EditStaff(request, user.StaffId);
            return Response("ok");
        }


        /// <summary>
        ///编辑员工登录密码
        /// create by xingbo 19/06/12
        /// </summary>
        /// <remarks>
        /// Staff_Put_EditStaffPassword api/staff/editStaffPassword
        /// 以json字符串的形式提交
        /// </remarks>
        /// <param name="request">请求实体</param>
        /// <returns>Returns the AjaxBackData</returns>
        /// <response code="200">Returns the data</response>
        [HttpPut("editStaffPassword")]
        [ProducesResponseType(typeof(string), 200)]
        [ServiceFilter(typeof(AuthAttribute))]
        public AjaxResult<string> EditStaffPassword([FromBody]EditStaffPasswordRequestModel request)
        {
            #region 验证提交数据是否有误
            if (!ModelState.IsValid)
                foreach (var item in ModelState.Values)
                    foreach (var errordetails in item.Errors)
                        NotifyError("", errordetails.ErrorMessage);
            #endregion
            var user = _identityManager.UserInfo;
            _staffAppService.EditStaffPassword(request, user.StaffId, user.StaffId);
            return Response("ok");
        }
        /// <summary>
        /// 测试模式登录
        /// </summary>
        /// <remarks>
        /// Staff_Post_TestLogin api/staff/testLogin
        /// 以json字符串的形式提交
        /// Post api/user
        /// </remarks>
        /// <returns>Returns the AjaxBackData</returns>
        /// <response code="200">Returns the AuthorizedLoginResponseModel</response>
        [HttpPost("testLogin")]
        [ProducesResponseType(typeof(AuthorizedLoginResponseModel), 200)]
        public AjaxResult<AuthorizedLoginResponseModel> TestLogin()
        {
            #region 非测试模式不可用
#if (!DEBUG)
throw new AggregateException("非测试模式不可用");  
#endif
            #endregion

            string account = "admin";
            var userModel = _staffAppService.Get(null, account);
            var loginModel = new UserInfoPrincipal()
            {
                StaffId = userModel.Id,
                StaffType = userModel.StaffType,
                Account = userModel.Account,
                Name = userModel.NickName,
                OfficeId = userModel.OfficeId,
                OfficeName = "",
                Roles = null
            };
            string token = _identityManager.GenerateToken(loginModel);//生成token
            AuthorizedLoginResponseModel result = new AuthorizedLoginResponseModel()
            {
                Token = token,
                StaffInfo = userModel
            };
            return Response(result);


        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <remarks>
        /// Staff_Post_Login api/staff/login
        /// 以json字符串的形式提交
        /// Post api/staff/login
        /// </remarks>
        /// <returns>Returns the AjaxBackData</returns>
        /// <response code="200">Returns the AuthorizedLoginResponseModel</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthorizedLoginResponseModel), 200)]
        public AjaxResult<AuthorizedLoginResponseModel> Login([FromBody]LoginRequestModel request)
        {

            string account = "admin";
            var userModel = _staffAppService.Get(null, account);
            if (userModel == null)
            {
                NotifyError("", "账户不存在");
                return Response<AuthorizedLoginResponseModel>(null);
            }
            var loginModel = new UserInfoPrincipal()
            {
                StaffId = userModel.Id,
                StaffType = userModel.StaffType,
                Account = userModel.Account,
                Name = userModel.NickName,
                OfficeId = userModel.OfficeId,
                OfficeName = "",
                Roles = null
            };
            string token = _identityManager.GenerateToken(loginModel);//生成token
            AuthorizedLoginResponseModel result = new AuthorizedLoginResponseModel()
            {
                Token = token,
                StaffInfo = userModel
            };
            return Response(result);


        }
    }
}