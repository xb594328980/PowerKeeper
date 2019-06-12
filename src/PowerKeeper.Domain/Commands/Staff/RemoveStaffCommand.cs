using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 删除员工
    /// create by xingbo 19/06/12
    /// </summary>
    public class RemoveStaffCommand : StaffCommand
    {
        public RemoveStaffCommand()
        {
            
        }
        public RemoveStaffCommand(Guid id, Guid updateBy, DateTime updateDate, DelFlagEnum delflag = DelFlagEnum.Deleted)
        {
            this.Id = id;
            this.UpdateBy = updateBy;
            this.UpdateDate = updateDate;
            this.DelFlag = (int)delflag;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveStaffValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
