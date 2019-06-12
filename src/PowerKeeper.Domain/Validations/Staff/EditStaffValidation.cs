using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Staff;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    /// 编辑员工信息
    /// create by xingbo 19/06/12
    /// </summary>
    public class EditStaffValidation : StaffValidation<EditStaffCommand>
    {
        public EditStaffValidation()
        {
            ValidateId();
            ValidateNickName();
            ValidateAccount();
            ValidateEmail();
            ValidateMobile();
            ValidateStaffType();
            ValidateState();
            ValidateUpdateBy();
            ValidateUpdateDate();
            ValidateRemark();
            ValidateOfficeId();
        }
    }
}
