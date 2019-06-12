using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PowerKeeper.Domain.Commands.Resource;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    /// 员工基础验证
    /// create by xingbo 19/06/06
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StaffValidation<T> : BaseValidation<T> where T : StaffCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNickName()
        {
            RuleFor(c => c.NickName)
                .NotEmpty()
                .Length(2, 64).WithMessage("昵称长度在2~64个字符之间")
                .NotEqual(string.Empty).WithMessage("昵称不能为空");
        }
        protected void ValidateAccount()
        {
            RuleFor(c => c.Account)
                .NotEmpty()
                .Length(2, 64).WithMessage("账户长度在2~64个字符之间")
                .NotEqual(string.Empty).WithMessage("账户不能为空");
        }
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .EmailAddress();
        }
        protected void ValidateMobile()
        {
            RuleFor(c => c.Mobile)
                .Must(HavePhone).WithMessage("手机号不合法");
        }
        protected void ValidateOfficeId()
        {
            RuleFor(c => c.OfficeId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty()
                .Length(2, 64).WithMessage("密码长度在2~64个字符之间");
        }

        protected void ValidateStaffType()
        {
            RuleFor(c => c.StaffType)
                .NotEmpty()
                .Must(x => IsEnumVal<StaffTypeEnum>(x)).WithMessage("员工类型不合法"); ;
        }

        protected void ValidateState()
        {
            RuleFor(c => c.State)
                .NotEmpty()
                .Must(x => IsEnumVal<StaffStateEnum>(x)).WithMessage("状态类型不合法"); ;
        }
        protected void ValidateCreateBy()
        {
            RuleFor(c => c.CreateBy)
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
                .Must(x => IsEnumVal<DelFlagEnum>(x)).WithMessage("删除标志不合法"); ; ;
        }
    }
}
