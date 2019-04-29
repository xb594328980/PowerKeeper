using System;
using System.Collections.Generic;
using System.Text;
using PowerKeeper.Domain.Core.Events;

namespace PowerKeeper.Domain.Events.Staff
{
    /// <summary>
    /// 员工删除事件
    /// <remarks>create by xingbo 19/01/04</remarks>
    /// </summary>
    public class StaffDeletedEvent : Event
    {
        public StaffDeletedEvent(Models.Staff staff)
            : this(staff.Id,
                staff.DelFlag,
                staff.Remark,
                staff.UpdateDate.Value,
                staff.UpdateBy.Value
            )
        {
        }
        public StaffDeletedEvent(Guid id,
            int delFlag,
            string remark,
            DateTime updateDate,
            Guid updateBy) : base(id, "StaffDeletedEvent")
        {
            Id = id;
            DelFlag = delFlag;
            Remark = remark;
            UpdateDate = updateDate;
            UpdateBy = updateBy;
        }
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; protected set; }


        /// <summary>
        /// 编辑人
        /// </summary>
        public Guid UpdateBy { get; protected set; }


        /// <summary>
        /// 编辑日期
        /// </summary>
        public DateTime UpdateDate { get; protected set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; protected set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int DelFlag { get; protected set; }
    }
}
