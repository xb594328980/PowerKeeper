using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Validations.Office;

namespace PowerKeeper.Domain.Commands.Office
{
    /// <summary>
    ///创建组织机构命令
    /// <remarks>create by xingbo 18/12/18</remarks>
    /// </summary>
    public class CreateOfficeCommand : OfficeCommand
    {
        public CreateOfficeCommand()
        {

        }
        // set 受保护，只能通过构造函数方法赋值
        public CreateOfficeCommand(
            Guid id,
            string officeName,
            string officePhone,
            string officeCode,
            int officeType,
            Guid parentId,
            string parentIds,
            Guid createBy,
            DateTime createDate,
            int delFlag = 0,
            string remark = null,
            DateTime? updateDate = null,
            Guid? updateBy = null)
        {
            Id = id;
            OfficeName = officeName;
            OfficePhone = officePhone;
            OfficeCode = officeCode;
            OfficeType = officeType;
            ParentId = parentId;
            ParentIds = parentIds;
            CreateDate = createDate;
            CreateBy = createBy;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateOfficeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
