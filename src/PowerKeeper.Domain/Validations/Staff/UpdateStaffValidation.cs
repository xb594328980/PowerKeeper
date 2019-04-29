using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Staff;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    ///  修改员工验证
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class UpdateStaffValidation : StaffValidation<UpdateStaffCommand>
    {

        public UpdateStaffValidation()
        {
            ValidateId();
            ValidateStaffName();
            ValidateStaffType();
            ValidateOfficeId();
            ValidateAccount();
            ValidateMobile();
            ValidateEmail();
            ValidateEnabledFlag();
            ValidateLoginFlag();

            ValidateUpdateBy();
            ValidateUpdateDate();
            ValidateRemark();
            ValidateDelFlag();
        }
    }
}
