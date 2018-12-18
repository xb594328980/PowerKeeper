using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Commands.Office
{
    public class UpdateOfficeCommand : OfficeCommand
    {
        public UpdateOfficeCommand()
        {

        }
        // set 受保护，只能通过构造函数方法赋值
        public UpdateOfficeCommand(
            Guid id,
            string officeName,
            string officePhone,
            string officeCode,
            int officeType,
            Guid parentId,
            string parentIds,
            string remark,
            DateTime updateDate,
            Guid updateBy
            )
        {
            Id = id;
            OfficeName = officeName;
            OfficePhone = officePhone;
            OfficeCode = officeCode;
            OfficeType = officeType;
            ParentId = parentId;
            ParentIds = parentIds;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
