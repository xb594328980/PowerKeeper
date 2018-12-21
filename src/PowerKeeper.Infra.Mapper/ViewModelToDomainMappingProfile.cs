using AutoMapper;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Commands.Office;
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

            CreateMap<OfficeViewModel, RemoveOfficeCommand>()
                .ConstructUsing(c => new RemoveOfficeCommand());

//            CreateMap<ClassViewModel, AddClassCommand>()
//                .ConstructUsing(c => new AddClassCommand(c.Name, c.GradeName, c.CreateTime));
//            CreateMap<ClassViewModel, UpdateClassCommand>()
//                .ConstructUsing(c => new UpdateClassCommand(c.Id, c.Name, c.GradeName, c.CreateTime));
//            CreateMap<ClassViewModel, RemoveClassCommand>()
//                .ConstructUsing(c => new RemoveClassCommand(c.Id));
//
//            CreateMap<UserInfoViewModel, UserInfo>();
//            CreateMap<AnswerViewModel, Answer>();
        }
    }
}