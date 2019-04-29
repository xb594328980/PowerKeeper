using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Staff;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    ///  删除员工验证
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class DeleteStaffValidation : StaffValidation<DeleteStaffCommand>
    {

        public DeleteStaffValidation()
        {
            ValidateId();
            ValidateUpdateBy();
            ValidateUpdateDate();
            ValidateRemark();
            ValidateDelFlag();
        }
    }
}
