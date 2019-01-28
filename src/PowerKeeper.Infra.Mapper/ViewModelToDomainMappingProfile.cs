using AutoMapper;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Infra.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {

            ;
            //这里以后会写领域命令，所以不能和DomainToViewModelMappingProfile写在一起。
            //学生视图模型 -> 添加新学生命令模型
            CreateMap<OfficeViewModel, CreateOfficeCommand>();
            CreateMap<OfficeViewModel, UpdateOfficeCommand>();
            CreateMap<OfficeViewModel, DeleteOfficeCommand>();


            CreateMap<StaffViewModel, CreateStaffCommand>();
            CreateMap<StaffViewModel, UpdateStaffCommand>();
            CreateMap<StaffViewModel, DeleteStaffCommand>();
            CreateMap<CreateStaffCommand, Staff>()
                .ConstructUsing(c =>
                    new Staff(c.Id, c.StaffName, c.StaffType, c.OfficeId, c.Account,c.Password, c.Mobile, c.Email, c.EnabledFlag, c.LoginFlag, c.CreateBy, c.CreateDate, c.DelFlag, c.Remark, c.UpdateDate, c.UpdateBy));
            CreateMap<UpdateStaffCommand, Staff>()
                .ConstructUsing(c =>
                    new Staff(c.Id, c.StaffName, c.StaffType, c.OfficeId, c.Account, c.Password, c.Mobile, c.Email, c.EnabledFlag, c.LoginFlag, c.CreateBy, c.CreateDate, c.DelFlag, c.Remark, c.UpdateDate, c.UpdateBy));
            CreateMap<DeleteStaffCommand, Staff>()
                .ConstructUsing(c =>
                    new Staff(c.Id, c.StaffName, c.StaffType, c.OfficeId, c.Account, c.Password, c.Mobile, c.Email, c.EnabledFlag, c.LoginFlag, c.CreateBy, c.CreateDate, c.DelFlag, c.Remark, c.UpdateDate, c.UpdateBy));









        }
    }
}