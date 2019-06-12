using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using MediatR;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Domain.Events.Office;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Tool.Security.Encryptors;

namespace PowerKeeper.Domain.CommandHandlers
{
    /// <summary>
    /// 员工命令处理
    /// create by xingbo 19/06/10
    /// </summary>
    public class StaffCommandHandler : CommandHandler,
        IRequestHandler<CreateStaffCommand, Unit>,
        IRequestHandler<EditStaffCommand, Unit>,
        IRequestHandler<EditStaffPasswordCommand, Unit>,
        IRequestHandler<RemoveStaffCommand, Unit>
    {
        #region MyRegion
        // 注入仓储接口
        private readonly IOfficeRepository _officeRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IStaffRoleRepository _staffRoleRepository;
        private readonly IMapper _mapper;
        private readonly Md5Encryptor _md5Encryptor;
        public StaffCommandHandler(IUnitOfWork uow,
            IMediatorHandler bus,
            IOfficeRepository officeRepository,
            IRoleRepository roleRepository,
            IStaffRoleRepository staffRoleRepository,
            IStaffRepository staffRepository, IMapper mapper) : base(uow, bus)
        {
            _officeRepository = officeRepository;
            _roleRepository = roleRepository;
            _staffRepository = staffRepository;
            _staffRoleRepository = staffRoleRepository;
            _mapper = mapper;
            _md5Encryptor = new Md5Encryptor();
        }
        #endregion
        #region CreateStaff
        /// <summary>
        /// 创建员工
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 命令验证
                if (!request.IsValid())
                {
                    // 错误信息收集
                    NotifyValidationErrors(request);
                    return Task.FromResult(new Unit());
                }
                var staffInfo = _mapper.Map<CreateStaffCommand, Staff>(request);
                staffInfo.Password = _md5Encryptor.Encrypt(staffInfo.Password);
                // 判断组织机构编码或名称是否存在
                // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理

                if (_staffRepository.GetAll(x => x.Account == request.Account).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "Account已存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!string.IsNullOrWhiteSpace(request.Mobile) && _staffRepository.GetAll(x => x.Mobile == request.Mobile).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "手机号已存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!string.IsNullOrWhiteSpace(request.Email) && _staffRepository.GetAll(x => x.Email == request.Email).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "邮箱已存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!_officeRepository.GetAll(x => x.Id == request.OfficeId).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "所选组织机构不存在！"));
                    return Task.FromResult(new Unit());
                }
                if (request.RoleList != null && request.RoleList.Any() && _roleRepository.GetAll(x => request.RoleList.Contains(x.Id)).Count() == request.RoleList.Length)
                {
                    _bus.RaiseEvent(new DomainNotification("", "所选角色不存在！"));
                    return Task.FromResult(new Unit());
                }
                _staffRepository.Add(staffInfo);
                //存在角色则插入角色
                if (request.RoleList != null && request.RoleList.Any())
                {
                    var staffRoleList =
                        request.RoleList.Select(x => new StaffRole() { RoleId = x, StaffId = staffInfo.Id });
                    _staffRoleRepository.Add(staffRoleList);
                }
                // 统一提交
                if (!Commit())
                    throw new AggregateException("提交失败");
            }
            catch (Exception e)
            {
                _bus.RaiseEvent(new DomainNotification("", $"系统异常，发生未知错误:{e.Message}"));
            }
            return Task.FromResult(new Unit());
        }
        #endregion

        #region EditStaff
        public Task<Unit> Handle(EditStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 命令验证
                if (!request.IsValid())
                {
                    // 错误信息收集
                    NotifyValidationErrors(request);
                    return Task.FromResult(new Unit());
                }
                var staffInfo = _mapper.Map<EditStaffCommand, Staff>(request);
                var oldStaffInfo = _staffRepository.Get(request.Id);
                if (oldStaffInfo == null)
                {
                    _bus.RaiseEvent(new DomainNotification("", "目标记录不存在"));
                    return Task.FromResult(new Unit());
                }
                // 判断组织机构编码或名称是否存在
                // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理

                if (oldStaffInfo.Account != request.Account && _staffRepository.GetAll(x => x.Account == request.Account).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "Account已存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!string.IsNullOrWhiteSpace(request.Mobile) && oldStaffInfo.Mobile != request.Mobile && _staffRepository.GetAll(x => x.Mobile == request.Mobile).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "手机号已存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!string.IsNullOrWhiteSpace(request.Email) && oldStaffInfo.Email != request.Email && _staffRepository.GetAll(x => x.Email == request.Email).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "邮箱已存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!_officeRepository.GetAll(x => x.Id == request.OfficeId).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "所选组织机构不存在！"));
                    return Task.FromResult(new Unit());
                }
                if (request.RoleList != null && request.RoleList.Any() && _roleRepository.GetAll(x => request.RoleList.Contains(x.Id)).Count() == request.RoleList.Length)
                {
                    _bus.RaiseEvent(new DomainNotification("", "所选角色不存在！"));
                    return Task.FromResult(new Unit());
                }
                oldStaffInfo.Account = staffInfo.Account;
                oldStaffInfo.NickName = staffInfo.NickName;
                oldStaffInfo.StaffType = staffInfo.StaffType;
                oldStaffInfo.State = staffInfo.State;
                oldStaffInfo.UpdateBy = staffInfo.UpdateBy;
                oldStaffInfo.UpdateDate = staffInfo.UpdateDate;
                oldStaffInfo.Remark = staffInfo.Remark;
                oldStaffInfo.Mobile = staffInfo.Mobile;
                oldStaffInfo.Email = staffInfo.Email;
                _staffRepository.Update(oldStaffInfo);
                _staffRoleRepository.RemoveAndInsert(staffInfo.Id, (request.RoleList != null && request.RoleList.Any()) ? request.RoleList : new Guid[0]);
                // 统一提交
                if (!Commit())
                    throw new AggregateException("提交失败");
            }
            catch (Exception e)
            {
                _bus.RaiseEvent(new DomainNotification("", $"系统异常，发生未知错误:{e.Message}"));
            }
            return Task.FromResult(new Unit());
        }


        #endregion

        #region EditStaffPassword
        public Task<Unit> Handle(EditStaffPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 命令验证
                if (!request.IsValid())
                {
                    // 错误信息收集
                    NotifyValidationErrors(request);
                    return Task.FromResult(new Unit());
                }
                if (request.NewPassword == request.Password)
                {
                    _bus.RaiseEvent(new DomainNotification("", "新密码与原密码不能一致"));
                    return Task.FromResult(new Unit());
                }
                var oldPassword = _md5Encryptor.Encrypt(request.Password);
                var staffInfo = _staffRepository.GetAll(x => x.Id == request.Id && (string.IsNullOrWhiteSpace(request.NewPassword) || x.Password == oldPassword))?.SingleOrDefault();
                if (staffInfo == null)
                {
                    _bus.RaiseEvent(new DomainNotification("", "原密码错误，请重新输入"));
                    return Task.FromResult(new Unit());
                }
                staffInfo.Password = _md5Encryptor.Encrypt(request.NewPassword);
                staffInfo.UpdateDate = request.UpdateDate;
                staffInfo.UpdateBy = request.UpdateBy;
                _staffRepository.Update(staffInfo);
                // 统一提交
                if (!Commit())
                    throw new AggregateException("修改密码失败");
            }
            catch (Exception e)
            {
                _bus.RaiseEvent(new DomainNotification("", $"系统异常，发生未知错误:{e.Message}"));
            }
            return Task.FromResult(new Unit());
        }


        #endregion



        #region RemoveStaff

        public Task<Unit> Handle(RemoveStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 命令验证
                if (!request.IsValid())
                {
                    // 错误信息收集
                    NotifyValidationErrors(request);
                    return Task.FromResult(new Unit());
                }
                var staffInfo = _staffRepository.Get(request.Id);
                if (staffInfo == null)
                    return Task.FromResult(new Unit());
                staffInfo.UpdateDate = request.UpdateDate;
                staffInfo.UpdateBy = request.UpdateBy;
                staffInfo.DelFlag = request.DelFlag;
                _staffRepository.Update(staffInfo);
                // 统一提交
                if (!Commit())
                    throw new AggregateException("提交失败");
            }
            catch (Exception e)
            {
                _bus.RaiseEvent(new DomainNotification("", $"系统异常，发生未知错误:{e.Message}"));
            }
            return Task.FromResult(new Unit());
        }

        #endregion


    }
}
