using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Infra.Tool.Maps;

namespace PowerKeeper.Application.Services
{
    /// <summary>
    /// 员工服务实现
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class StaffAppService : IStaffAppService
    {
        // 注入仓储接口
        private readonly IStaffRepository _staffRepository;
        //用来进行DTO
        private readonly IMapper _mapper;
        //中介者 总线
        private readonly IMediatorHandler _bus;
        public StaffAppService(
            IStaffRepository staffRepository,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public void Dispose()
        {
            _staffRepository.Dispose();
        }

        public void Add(StaffViewModel staffViewModel)
        {
            var command = staffViewModel.MapTo<CreateStaffCommand>();
            _bus.SendCommand(command);
        }

        public IEnumerable<StaffViewModel> GetAll()
        {
            return _staffRepository.GetAll(x => true).MapToList<StaffViewModel>();
        }

        public StaffViewModel GetById(Guid id)
        {
            return _staffRepository.GetById(id).MapTo<StaffViewModel>();
        }

        public void Update(StaffViewModel staffViewModel)
        {
            var command = staffViewModel.MapTo<UpdateStaffCommand>();
            _bus.SendCommand(command);
        }

        public void Delete(StaffViewModel staffViewModel)
        {
            var command = staffViewModel.MapTo<DeleteStaffCommand>();
            _bus.SendCommand(command);
        }
    }
}
