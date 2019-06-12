using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Office;
using PowerKeeper.Domain.Validations.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 创建员工命令
    /// create by xingbo 19/06/10
    /// </summary>
    public class CreateStaffCommand : StaffCommand
    {
        public CreateStaffCommand()
        {

        }

        public CreateStaffCommand(Guid id,
            int staffType,
            Guid officeId,
            string nickName,
            string account,
            string password,
            int state,
            Guid createBy,
            Guid[] roleList,
            string mobile = null,
            string email = null,
            DateTime? createDate = null,
            string remark = null,
            int delFlag = (int)DelFlagEnum.Normal) : base(id, staffType, officeId, nickName, account, password, state, createBy, roleList, mobile, email, createDate, remark, null, null, delFlag)
        {
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateStaffValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
