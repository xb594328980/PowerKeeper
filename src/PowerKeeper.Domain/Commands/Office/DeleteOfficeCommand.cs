using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Office;
using PowerKeeper.Infra.Enum;

namespace PowerKeeper.Domain.Commands.Office
{
    /// <summary>
    /// 删除组织机构命令
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class DeleteOfficeCommand : OfficeCommand
    {
        public DeleteOfficeCommand()
        {

        }
        // set 受保护，只能通过构造函数方法赋值
        public DeleteOfficeCommand(
            Guid id,
            DateTime updateDate,
            Guid updateBy,
            string remark = null,
            int delFlag = (int)DelFlagEnum.Deleted)
        {
            Id = id;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
    public override bool IsValid()
    {
        ValidationResult = new DeleteOfficeValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
}
