using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Events.Staff;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Tool.Exceptions;
using PowerKeeper.Infra.Tool.Helpers;
using PowerKeeper.Infra.Tool.Maps;

namespace PowerKeeper.Domain.CommandHandlers
{
    /// <summary>
    /// 员工命令处理程序
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class StaffCommandHandler : CommandHandler,
        IRequestHandler<CreateStaffCommand, Unit>,
        IRequestHandler<UpdateStaffCommand, Unit>,
        IRequestHandler<DeleteStaffCommand, Unit>
    {
        private readonly IStaffRepository _staffRepository;
        public StaffCommandHandler(IUnitOfWork uow, IMediatorHandler bus, IStaffRepository staffRepository) : base(uow, bus)
        {
            _staffRepository = staffRepository;
        }

        public Task<Unit> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }
            if (_staffRepository.GetAll(x => x.Account == request.Account).Any())
            {
                NotifyValidationError("登录名称已存在", "Account");
                return Task.FromResult(new Unit());
            }
            if (_staffRepository.GetAll(x => x.Mobile == request.Mobile).Any())
            {
                NotifyValidationError("手机号已存在", "Mobile");
                return Task.FromResult(new Unit());
            }
            if (!string.IsNullOrWhiteSpace(request.Email) && _staffRepository.GetAll(x => x.Email == request.Email).Any())
            {
                NotifyValidationError("邮箱已存在", "Email");
                return Task.FromResult(new Unit());
            }
            try
            {
                Staff staff = new Staff(request.Id,
                    request.StaffName,
                    request.StaffType,
                    request.OfficeId,
                    request.Account,
                    Encrypt.Md5By32(request.Password),
                    request.Mobile,
                    request.Email,
                    request.EnabledFlag,
                    request.LoginFlag,
                    request.CreateBy,
                    request.CreateDate,
                    request.DelFlag,
                    request.Remark,
                    null,
                    null);
                _staffRepository.Add(staff);
                if (Commit())
                {
                    var staffCreatedEvent = new StaffCreatedEvent(staff);
                    _bus.RaiseEvent(staffCreatedEvent);
                    return Task.FromResult(new Unit());
                }
                throw new Warning($"添加失败，请联系管理员");
            }
            catch (Warning ex)
            {
                NotifyValidationError($"业务异常：{ex.Message}", "BizErr");
                return Task.FromResult(new Unit());
            }
            catch (Exception ex)
            {
                NotifyValidationError($"系统异常：{ex.Message}", "SystemErr");
                return Task.FromResult(new Unit());
            }
        }

        public Task<Unit> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            Staff oldStaff = _staffRepository.GetById(request.Id);
            if (oldStaff == null)
            {
                NotifyValidationError("员工信息不存在", "Account");
                return Task.FromResult(new Unit());
            }
            if (!request.Account.Equals(oldStaff.Account) && _staffRepository.GetAll(x => x.Account == request.Account && x.DelFlag == 0).Any())
            {
                NotifyValidationError("登录名称已存在", "Account");
                return Task.FromResult(new Unit());
            }
            if (!request.Mobile.Equals(oldStaff.Mobile) && _staffRepository.GetAll(x => x.Mobile == request.Mobile).Any())
            {
                NotifyValidationError("手机号已存在", "Mobile");
                return Task.FromResult(new Unit());
            }
            if (!string.IsNullOrWhiteSpace(request.Email) && !request.Mobile.Equals(oldStaff.Mobile) && _staffRepository.GetAll(x => x.Email == request.Email).Any())
            {
                NotifyValidationError("邮箱已存在", "Email");
                return Task.FromResult(new Unit());
            }
            try
            {
                Staff staff = new Staff(request.Id,
                    request.StaffName,
                    request.StaffType,
                    request.OfficeId,
                    request.Account,
                    oldStaff.Password,
                    request.Mobile,
                    request.Email,
                    request.EnabledFlag,
                    oldStaff.LoginFlag,
                    oldStaff.CreateBy,
                    oldStaff.CreateDate,
                    request.DelFlag,
                    request.Remark,
                    request.UpdateDate,
                    request.UpdateBy);
                _staffRepository.Update(staff);
                if (Commit())
                {

                    var staffUpdatedEvent = new StaffUpdatedEvent(staff);
                    _bus.RaiseEvent(staffUpdatedEvent);
                    return Task.FromResult(new Unit());
                }
                throw new Warning($"修改失败，请联系管理员");
            }
            catch (Warning ex)
            {
                NotifyValidationError($"业务异常：{ex.Message}", "BizErr");
                return Task.FromResult(new Unit());
            }
            catch (Exception ex)
            {
                NotifyValidationError($"系统异常：{ex.Message}", "SystemErr");
                return Task.FromResult(new Unit());
            }
        }

        public Task<Unit> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }
            Staff oldStaff = _staffRepository.GetById(request.Id);
            if (oldStaff == null)
            {
                NotifyValidationError("员工信息不存在", "Account");
                return Task.FromResult(new Unit());
            }
            try
            {
                Staff staff = request.MapTo<Staff>();
                List<string> fieldNames = new List<string>() { "DelFlag", "UpdateDate", "UpdateBy" };
                if (!string.IsNullOrWhiteSpace(staff.Remark))
                    fieldNames.Add("Remark");
                _staffRepository.Update(staff, fieldNames);
                if (Commit())
                {
                    var staffDeletedEvent = new StaffDeletedEvent(staff);
                    _bus.RaiseEvent(staffDeletedEvent);
                    return Task.FromResult(new Unit());
                }
                throw new Warning($"删除失败，请联系管理员");
            }
            catch (Warning ex)
            {
                NotifyValidationError($"业务异常：{ex.Message}", "BizErr");
                return Task.FromResult(new Unit());
            }
            catch (Exception ex)
            {
                NotifyValidationError($"系统异常：{ex.Message}", "SystemErr");
                return Task.FromResult(new Unit());
            }
        }
    }
}
