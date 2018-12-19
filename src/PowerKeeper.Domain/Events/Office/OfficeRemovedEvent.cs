using PowerKeeper.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Events.Office
{
    public class OfficeRemovedEvent : Event
    {
        public OfficeRemovedEvent(Guid id,
            int delFlag,
            string remark,
            DateTime updateDate,
            Guid updateBy) : base(id, "OfficeRemovedEvent")
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
