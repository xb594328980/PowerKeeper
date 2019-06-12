using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Staff;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    /// 创建员工验证
    /// create by xingbo 19/06/12
    /// </summary>
    public class CreateStaffValidation : StaffValidation<CreateStaffCommand>
    {


        public CreateStaffValidation()
        {
            ValidateId();
            ValidateOfficeId();
            ValidateNickName();
            ValidateStaffType();
            ValidateState();
            ValidateEmail();
            ValidateCreateBy();
            ValidateCreateDate();
            ValidateDelFlag();
            ValidateRemark();
            ValidateMobile();
            ValidateAccount();
            ValidatePassword();
        }
    }
}
