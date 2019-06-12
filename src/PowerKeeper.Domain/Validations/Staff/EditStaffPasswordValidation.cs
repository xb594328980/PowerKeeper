using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Staff;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    /// 修改员工登录密码
    /// create by xingbo 19/06/12
    /// </summary>
    public class EditStaffPasswordValidation : StaffValidation<EditStaffPasswordCommand>
    {
        public EditStaffPasswordValidation()
        {
            ValidateId();
            ValidatePassword();
            ValidateUpdateBy();
            ValidateUpdateDate();
        }
    }
}
