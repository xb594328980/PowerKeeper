using AutoMapper;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Infra.Tool.Maps;

namespace PowerKeeper.Application.Services
{
    /// <summary>
    /// 组织机构服务实现
    /// <remarks>create by xingbo 18/12/19</remarks>
    /// </summary>
    public class OfficeAppService : IOfficeAppService
    {
        // 注入仓储接口
        private readonly IOfficeRepository _officeRepository;
        //用来进行DTO
        private readonly IMapper _mapper;
        //中介者 总线
        private readonly IMediatorHandler _bus;
        public OfficeAppService(
            IOfficeRepository officeRepository,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public void Add(OfficeViewModel officeViewModel)
        {
            var command = officeViewModel.MapTo<CreateOfficeCommand>();
            _bus.SendCommand(command);
        }

        public void Dispose()
        {
            _officeRepository.Dispose();
        }

        public IEnumerable<OfficeViewModel> GetAll()
        {
            return _officeRepository.GetAll(x => true).MapToList<OfficeViewModel>();
            //return _mapper.Map<IEnumerable<OfficeViewModel>>(_officeRepository.GetAll(x => true));
        }

        public OfficeViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(OfficeViewModel officeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(OfficeViewModel officeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
