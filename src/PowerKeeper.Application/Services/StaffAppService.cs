using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Application.RequestModels;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Tool.Maps;

namespace PowerKeeper.Application.Services
{
    /// <summary>
    /// 员工
    /// create by xingbo 19/06/11
    /// </summary>
    public class StaffAppService : IStaffAppService
    {

        private readonly IStaffRepository _staffRepository;
        //用来进行DTO
        private readonly IMapper _mapper;
        //中介者 总线
        private readonly IMediatorHandler _bus;
        public StaffAppService(IStaffRepository staffRepository,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _bus = bus;
        }


        public StaffViewModel Get(Guid? id = null, string account = null, string mobile = null, string email = null)
        {
            return _staffRepository.Get(id, account, mobile, email)?.MapTo<StaffViewModel>();

        }

        public IList<StaffViewModel> Gets(string account = null, string mobile = null, string email = null, string nickName = null,
            int? take = null, int skip = 0)
        {
            var list = _staffRepository.GetAll(x =>
                (string.IsNullOrWhiteSpace(nickName) || x.NickName.Contains(nickName))
                && (string.IsNullOrWhiteSpace(account) || x.Account == account)
                && (string.IsNullOrWhiteSpace(email) || x.Email == (email))
                && (string.IsNullOrWhiteSpace(mobile) || x.Mobile == (mobile))).OrderByDescending(x => x.CreateDate);
            return take.HasValue ? list.Skip(skip).Take(take.Value).ToList()?.MapToList<StaffViewModel>() : list.ToList()?.MapToList<StaffViewModel>();
        }

        public Guid CreateStaff(CreateStaffRequestModel request, Guid createBy, Guid? id = null, DateTime? createDateTime = null,
            DelFlagEnum delFlag = DelFlagEnum.Normal)
        {
            CreateStaffCommand command = request.MapTo<CreateStaffCommand>();
            command.Id = id ?? Guid.NewGuid();
            command.CreateBy = createBy;
            command.CreateDate = createDateTime ?? DateTime.Now;
            command.DelFlag = (int)delFlag;
            _bus.SendCommand(command);
            return command.Id;
        }

        public void EditStaff(EditStaffRequestModel request, Guid updateBy, DateTime? updateDateTime = null)
        {
            EditStaffCommand command = request.MapTo<EditStaffCommand>();
            command.UpdateBy = updateBy;
            command.UpdateDate = updateDateTime ?? DateTime.Now;
            _bus.SendCommand(command);
        }

        public void RemoveStaff(Guid id, Guid updateBy, DateTime? updateDateTime = null)
        {
            RemoveStaffCommand command = new RemoveStaffCommand(id, updateBy, updateDateTime ?? DateTime.Now);
            _bus.SendCommand(command);
        }

        public void EditStaffPassword(EditStaffPasswordRequestModel request, Guid id, Guid updateBy, DateTime? updateDateTime = null)
        {
            EditStaffPasswordCommand command = new EditStaffPasswordCommand(id, request.Password, request.NewPassword, updateBy, updateDateTime ?? DateTime.Now);
            _bus.SendCommand(command);
        }
    }
}
