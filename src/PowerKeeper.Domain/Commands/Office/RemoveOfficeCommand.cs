using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Office;

namespace PowerKeeper.Domain.Commands.Office
{
    /// <summary>
    /// 删除组织机构命令
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class RemoveOfficeCommand : OfficeCommand
    {
        public RemoveOfficeCommand()
        {

        }
        // set 受保护，只能通过构造函数方法赋值
        public RemoveOfficeCommand(
            Guid id,
            DateTime updateDate,
            Guid updateBy,
            string remark = null,
            int delFlag = 1)
        {
            Id = id;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveOfficeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
