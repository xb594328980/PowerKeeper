using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Commands.Staff;

namespace PowerKeeper.Domain.Validations.Staff
{
    /// <summary>
    /// 删除员工验证
    /// create by xingbo 19/06/12
    /// </summary>
   public  class RemoveStaffValidation: StaffValidation<RemoveStaffCommand>
    {

        public RemoveStaffValidation()
        {
            ValidateId();
            ValidateUpdateBy();
            ValidateUpdateDate();
            ValidateDelFlag();
        }
    }
}
