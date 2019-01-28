using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Staff;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Staff
{
    /// <summary>
    /// 删除员工命令模型
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class DeleteStaffCommand : StaffCommand
    {
        public DeleteStaffCommand(Guid id, DateTime updateDate,
            Guid updateBy, string remark = null, int delFlag = ((int)DelFlagEnum.Deleted))
        {
            Id = id;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
            DelFlag = delFlag;
            Remark = remark;
        }

        public DeleteStaffCommand()
        {
            
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteStaffValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
