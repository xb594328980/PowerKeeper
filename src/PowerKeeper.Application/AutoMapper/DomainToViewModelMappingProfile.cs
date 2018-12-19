using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Application.ViewModels;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {

            CreateMap<Office, OfficeViewModel>();
         


        }
    }
}
