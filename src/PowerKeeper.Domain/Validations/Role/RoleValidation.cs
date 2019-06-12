using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PowerKeeper.Domain.Commands.Role;

namespace PowerKeeper.Domain.Validations.Role
{
    /// <summary>
    /// 角色基础验证
    /// create by xingbo 19/06/06
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RoleValidation<T> : BaseValidation<T> where T : RoleCommand
    {

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
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
                .Must(x => (x == 1 || x == 0))
                .WithMessage("删除标志必须为0或1");
        }
    }
}
