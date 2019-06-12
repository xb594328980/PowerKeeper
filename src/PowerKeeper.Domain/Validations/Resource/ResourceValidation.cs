using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Resource;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Validations.Resource
{
    /// <summary>
    /// 资源基础验证
    /// create by xingbo 19/06/06
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResourceValidation<T> : BaseValidation<T> where T : ResourceCommand
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
                .NotEqual(string.Empty)
                .NotEmpty()
                .Length(0, 2000);
        }
        protected void ValidateResourceName()
        {
            RuleFor(c => c.ResourceName)
                .NotEmpty().WithMessage("资源名称名称不能为空")
                .Length(2, 64).WithMessage("资源名称在2~64个字符之间");
        }
        protected void ValidateResourceType()
        {
            RuleFor(c => c.ResourceType).Must(x => IsEnumVal<ResourceTypeEnum>(x)).WithMessage("资源类型不合法");
        }
        protected void ValidateResourceCode()
        {
            RuleFor(c => c.ResourceCode)
                .Length(2, 64).WithMessage("资源代码在2~64个字符之间");
        }

        protected void ValidateShowNamee()
        {
            RuleFor(c => c.ShowName)
                .Length(2, 64).WithMessage("资源显示名称长度在2~64个字符之间");
        }
        protected void ValidateInterfaceUrl()
        {
            RuleFor(c => c.InterfaceUrl)
                .Length(2, 128).WithMessage("接口链接长度在2~128个字符之间");
        }
        protected void ValidateResourceUrl()
        {
            RuleFor(c => c.ResourceUrl)
                .Length(2, 128).WithMessage("资源链接长度在2~128个字符之间");
        }

        protected void ValidateIsEnable()
        {
            RuleFor(c => c.IsEnable).Must(x => IsEnumVal<IsEnableEnum>(x)).WithMessage("是否启用值错误");
        }

        protected void ValidateIsShow()
        {
            RuleFor(c => c.IsShow).Must(x => IsEnumVal<IsShowEnum>(x)).WithMessage("是否显示值错误");
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
