using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Office;

namespace PowerKeeper.Domain.Validations.Office
{
    /// <summary>
    /// 创建组织机构验证
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class CreateOfficeValidation : OfficeValidation<CreateOfficeCommand>
    {
        public CreateOfficeValidation()
        {
            ValidateId();
            ValidateParentId();
            ValidateParentIds();
            ValidateOfficeType();
            ValidateOfficeCode();
            ValidateOfficeName();
            ValidateOfficePhone();
            ValidateCreateBy();
            ValidateCreateDate();
            ValidateRemark();
            ValidateDelFlag();

        }
    }
}
