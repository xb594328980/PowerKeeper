using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Validators;
using PowerKeeper.Domain.Commands.Office;
using PowerKeeper.Domain.Commands.Staff;
using PowerKeeper.Domain.Validations.Office;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    ///  创建员工验证
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class CreateStaffValidation : StaffValidation<CreateStaffCommand>
    {
        public CreateStaffValidation()
        {
            ValidateId();
            ValidateStaffName();
            ValidateStaffType();
            ValidateOfficeId();
            ValidateAccount();
            ValidatePassword();
            ValidateMobile();
            ValidateEmail();
            ValidateEnabledFlag();
            ValidateLoginFlag();

            ValidateCreateBy();
            ValidateCreateDate();
            ValidateRemark();
            ValidateDelFlag();

        }
    }
}
