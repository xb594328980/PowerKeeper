using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Office;

namespace PowerKeeper.Domain.Validations.Office
{
    /// <summary>
    /// 修改组织机构
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class UpdateOfficeValidation : OfficeValidation<UpdateOfficeCommand>
    {
        public UpdateOfficeValidation()
        {
            ValidateId();
            ValidateParentId();
            ValidateParentIds();
            ValidateOfficeType();
            ValidateOfficeCode();
            ValidateOfficeName();
            ValidateOfficePhone();
            ValidateUpdateBy();
            ValidateUpdateDate();
            ValidateRemark();
        }
    }
}
