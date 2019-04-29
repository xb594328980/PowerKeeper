using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    ///  员工基础验证
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class StaffValidation<T> : BaseValidation<T> where T : StaffCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateOfficeId()
        {
            RuleFor(c => c.OfficeId)
                .NotEqual(Guid.Empty).WithMessage("组织机构不能为空");
        }


        protected void ValidateStaffName()
        {
            RuleFor(c => c.StaffName)
                .NotEmpty().WithMessage("员工名称不能为空")
                .Length(2, 32).WithMessage("员工名称在2~32个字符之间");
        }
        protected void ValidateStaffType()
        {
            RuleFor(c => c.StaffType)
                .NotEmpty().WithMessage("员工类型不能为空")
                .Must((val) => IsEnumType<StaffTypeEnum>(val))
                .WithMessage("员工类型必须为2或1");
        }
        protected void ValidateAccount()
        {
            RuleFor(c => c.Account)
                .NotEmpty().WithMessage("登录账号不能为空")
                .Length(8, 32).WithMessage("登录账号在8~32个字符之间");
        }      
     
        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .Length(8, 32).WithMessage("密码需在8~32个字符之间");
        }
       
        protected void ValidateMobile()
        {
            RuleFor(c => c.Mobile)
                .NotEmpty().WithMessage("手机号不能为空")
                .Must(IsMobile)
                .WithMessage("手机号应该为11位");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("邮箱格式错误");
        }

        protected void ValidateEnabledFlag()
        {
            RuleFor(c => c.EnabledFlag)
                .NotEmpty().WithMessage("是否启用标志不能为空")
                .Must((val) => IsEnumType<EnabledFlag>(val))
                .WithMessage((val) => $"是否启用标志值:{val},不属于EnabledFlag的任何一项");
        }
        protected void ValidateLoginFlag()
        {
            RuleFor(c => c.LoginFlag)
                .NotEmpty().WithMessage("登录标志不能为空")
                .Must((val) => IsEnumType<StaffLoginFlagEnum>(val))
                .WithMessage((val) => $"登录标志值:{val},不属于StaffLoginFlagEnum中的任何一项");
        }


        protected void ValidateCreateBy()
        {
            RuleFor(c => c.CreateBy)
                .NotEmpty()
                .NotEqual(Guid.Empty).WithMessage("创建人不能为空");
        }
        protected void ValidateCreateDate()
        {
            RuleFor(c => c.CreateDate)
                .NotEmpty()
                .GreaterThan(new DateTime(1970, 1, 1)).WithMessage("创建时间不合法");
        }

        protected void ValidateUpdateBy()
        {
            RuleFor(c => c.UpdateBy)
                .NotEmpty()
                .NotEqual(Guid.Empty).WithMessage("修改人不能为空");
        }
        protected void ValidateUpdateDate()
        {
            RuleFor(c => c.UpdateDate)
                .NotEmpty()
                .GreaterThan(new DateTime(1970, 1, 1)).WithMessage("修改时间不合法");
        }

        protected void ValidateRemark()
        {
            RuleFor(c => c.Remark)
                .Length(0, 256)
                .WithMessage("备注在2~32个字符之间");
        }
        protected void ValidateDelFlag()
        {
            RuleFor(c => c.DelFlag).NotNull()
                .Must(x => IsEnumType<DelFlagEnum>(x))
                .WithMessage("删除标志必须为0或1");
        }


    }
}
