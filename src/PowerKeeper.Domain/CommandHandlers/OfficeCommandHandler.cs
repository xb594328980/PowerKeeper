using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PowerKeeper.Domain.Commands.Office;
using System.Threading;
using System.Threading.Tasks;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Models;
using PowerKeeper.Domain.Core.Notifications;
using PowerKeeper.Domain.Events.Office;
using PowerKeeper.Infra.Tool;
using PowerKeeper.Infra.Tool.Maps;

namespace PowerKeeper.Domain.CommandHandlers
{
    /// <summary>
    /// 组织机构命令处理程序
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class OfficeCommandHandler : CommandHandler,
         IRequestHandler<CreateOfficeCommand, Unit>,
         IRequestHandler<UpdateOfficeCommand, Unit>,
         IRequestHandler<RemoveOfficeCommand, Unit>
    {
        // 注入仓储接口
        private readonly IOfficeRepository _officeRepository;

        public OfficeCommandHandler(IUnitOfWork uow, IMediatorHandler bus, IOfficeRepository officeRepository) : base(uow, bus)
        {
            _officeRepository = officeRepository;
        }
        public Task<Unit> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
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
                // 实例化领域模型，这里才真正的用到了领域模型
                // 注意这里是通过构造函数方法实现

                Office office = new Office(request.Id,
                    request.OfficeName.Trim(),
                    request.OfficePhone?.Trim(),
                    request.OfficeCode?.Trim(),
                    request.OfficeType,
                    request.ParentId,
                    request.ParentIds?.Trim(),
                    request.CreateBy,
                    request.CreateDate,
                    request.DelFlag,
                    request.Remark?.Trim(),
                    request.UpdateDate,
                    request.UpdateBy);
                // 判断组织机构编码或名称是否存在
                // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
                if (!string.IsNullOrWhiteSpace(request.OfficeCode) && _officeRepository.GetAll(x => x.OfficeCode.Equals(request.OfficeCode)).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "组织机构编码已经存在！"));
                    return Task.FromResult(new Unit());
                }
                if (!string.IsNullOrWhiteSpace(request.OfficeName) && _officeRepository.GetAll(x => x.OfficeName.Equals(request.OfficeName)).Any())
                {
                    _bus.RaiseEvent(new DomainNotification("", "组织机构名称已经存在！"));
                    return Task.FromResult(new Unit());
                }
                _officeRepository.Add(office);
                // 统一提交
                if (Commit())
                {
                    OfficeCreatedEvent officeCreatedEvent = new OfficeCreatedEvent(request.Id,
                        request.OfficeName.Trim(),
                        request.OfficePhone?.Trim(),
                        request.OfficeCode?.Trim(),
                        request.OfficeType,
                        request.ParentId,
                        request.ParentIds?.Trim(),
                        request.CreateBy,
                        request.CreateDate,
                        request.DelFlag,
                        request.Remark?.Trim(),
                        request.UpdateDate,
                        request.UpdateBy);
                    _bus.RaiseEvent(officeCreatedEvent);
                }
            }
            catch (Exception e)
            {
                _bus.RaiseEvent(new DomainNotification("", $"系统异常，发生未知错误:{e.Message}"));
            }
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }
            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            Office old_office = _officeRepository.GetById(request.Id);
            Office office = request.MapTo(old_office);
            // 判断组织机构编码或名称是否存在
            // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
            if (_officeRepository.GetAll(x => x.OfficeCode == request.OfficeCode || x.OfficeName.Equals(request.OfficeName)).Any())
            {
                _bus.RaiseEvent(new DomainNotification("", "组织机构编号或名称已经存在！"));
                return Task.FromResult(new Unit());
            }
            _officeRepository.Add(office);
            // 统一提交
            if (Commit())
            {
                OfficeUpdatedEvent officUpdatedEvent = new OfficeUpdatedEvent(request.Id,
                    request.OfficeName.Trim(),
                    request.OfficePhone?.Trim(),
                    request.OfficeCode?.Trim(),
                    request.OfficeType,
                    request.ParentId,
                    request.ParentIds?.Trim(),
                    request.DelFlag,
                    request.Remark?.Trim(),
                    request.UpdateDate.Value,
                    request.UpdateBy.Value);
                _bus.RaiseEvent(officUpdatedEvent);
            }
            return Task.FromResult(new Unit());

        }

        public Task<Unit> Handle(RemoveOfficeCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }
            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现

            Office office = request.MapTo<Office>();
            // 判断组织机构编码或名称是否存在
            if (_officeRepository.GetAll(x => x.ParentId == request.Id).Any())
            {
                _bus.RaiseEvent(new DomainNotification("", "组织机构存在子级，不允许删除！"));
                return Task.FromResult(new Unit());
            }
            _officeRepository.Update(office);
            // 统一提交
            if (Commit())
            {
                OfficeRemovedEvent officeCreatedEvent = new OfficeRemovedEvent(request.Id,
                    request.DelFlag,
                    request.Remark?.Trim(),
                    request.UpdateDate.Value,
                    request.UpdateBy.Value);
                _bus.RaiseEvent(officeCreatedEvent);
            }
            return Task.FromResult(new Unit());
        }
    }
}
