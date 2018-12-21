using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Office;

namespace PowerKeeper.Domain.Validations.Office
{
    /// <summary>
    /// 删除组织机构
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class RemoveOfficeValidation : OfficeValidation<RemoveOfficeCommand>
    {
        public RemoveOfficeValidation()
        {
            ValidateId();
            ValidateUpdateBy();
            ValidateUpdateDate();
            ValidateRemark();
            ValidateDelFlag();
        }
    }
}
