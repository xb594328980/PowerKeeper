using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 修改密码
    /// create by xingbo 19/06/12
    /// </summary>
    public class EditStaffPasswordCommand : StaffCommand
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }

        public EditStaffPasswordCommand()
        {

        }
        public EditStaffPasswordCommand(Guid id, string password, string newPassword, Guid updateBy, DateTime updateDate)
        {
            this.Id = id;
            this.UpdateBy = updateBy;
            this.UpdateDate = updateDate;
            this.Password = password;
            this.NewPassword=newPassword;
        }
        public override bool IsValid()
        {
            ValidationResult = new EditStaffPasswordValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
