using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Staff;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 更新员工命令模型
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class UpdateStaffCommand : StaffCommand
    {
        public UpdateStaffCommand(Guid id,
            string staffName,
            int staffType,
            Guid officeId,
            string account,
            string mobile,
            string email,
            int enabledFlag,
            int loginFlag,
            string remark,
            DateTime updateDate,
            Guid updateBy)
        {
            Id = id;
            StaffName = staffName;
            StaffType = staffType;
            OfficeId = officeId;
            Account = account;
            Mobile = mobile;
            Email = email;
            EnabledFlag = enabledFlag;
            LoginFlag = loginFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        public UpdateStaffCommand()
        {
            Id = Guid.NewGuid();
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateStaffValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
