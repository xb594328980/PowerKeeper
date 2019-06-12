using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 修改员工信息
    /// create by xingbo 19/06/12
    /// </summary>
    public class EditStaffCommand : StaffCommand
    {
        public EditStaffCommand()
        {

        }

        public EditStaffCommand(Guid id,
            int staffType,
            Guid officeId,
            string nickName,
            string account,
            int state,
            Guid updateBy,
            Guid[] roleList,
            string mobile = null,
            string email = null,
            DateTime? updateDate = null,
            string remark = null) : base(id, staffType, officeId, nickName, account, null, state, Guid.Empty, roleList, mobile, email, null, remark, updateDate ?? DateTime.Now, updateBy)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new EditStaffValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
