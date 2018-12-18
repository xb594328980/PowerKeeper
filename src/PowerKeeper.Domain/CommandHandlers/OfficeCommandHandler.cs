using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Office;
using System.Threading;
using System.Threading.Tasks;
using Christ3D.Domain.Interfaces;
using PowerKeeper.Domain.Core.Bus;

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
        public OfficeCommandHandler(IUnitOfWork uow, IMediatorHandler bus) : base(uow, bus)
        {

        }
        public Task<Unit> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RemoveOfficeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
