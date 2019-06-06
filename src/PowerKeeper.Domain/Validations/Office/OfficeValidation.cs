using FluentValidation;
using PowerKeeper.Domain.Commands.Office;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Validations.Office
{
    /// <summary>
    /// 组织机构基础验证
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OfficeValidation<T> : BaseValidation<T> where T : OfficeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateParentId()
        {
            RuleFor(c => c.ParentId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateParentIds()
        {
            RuleFor(c => c.ParentIds)
                .Length(0, 2000);
        }
        protected void ValidateOfficeName()
        {
            RuleFor(c => c.OfficeName)
                .NotEmpty().WithMessage("组织机构名称不能为空")
                .Length(2, 32).WithMessage("组织机构名称在2~32个字符之间");
        }
        protected void ValidateOfficeType()
        {
            RuleFor(c => c.OfficeType)
                .NotNull()
                .Must(x => (x == 1 || x == 0))
                .WithMessage("组织机构类型必须为0或1");
        }
        protected void ValidateOfficeCode()
        {
            RuleFor(c => c.OfficeCode)
                .Length(2, 32).WithMessage("组织机构代码在2~32个字符之间");
        }

        protected void ValidateOfficePhone()
        {
            RuleFor(c => c.OfficePhone)
                .Must(HavePhone)
                .WithMessage("组织机构电话应该为11-13位");
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
