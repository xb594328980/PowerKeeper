using PowerKeeper.Domain.Validations.Office;
using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Staff;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 创建员工命令模型
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class CreateStaffCommand : StaffCommand
    {
        public CreateStaffCommand(Guid id,
            string staffName,
            int staffType,
            Guid officeId,
            string account,
            string password,
            string mobile,
            string email,
            int enabledFlag,
            int loginFlag,
            Guid createBy,
            DateTime createDate,
            int delFlag,
            string remark,
            DateTime? updateDate,
            Guid? updateBy)
        {
            Id = id;
            StaffName = staffName;
            StaffType = staffType;
            OfficeId = officeId;
            Account = account;
            Password = password;
            Mobile = mobile;
            Email = email;
            EnabledFlag = enabledFlag;
            LoginFlag = loginFlag;
            CreateDate = createDate;
            CreateBy = createBy;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        public CreateStaffCommand()
        {
            Id = Guid.NewGuid();
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateStaffValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
