using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PowerKeeper.Domain.Core.Models;

namespace PowerKeeper.Domain.Models
{
    public class StaffRole : ValueObject<StaffRole>
    {
        public StaffRole()
        {

        }
        /// <summary>
        /// 员工id
        /// </summary>
        [Key]
        public Guid StaffId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Key]
        public Guid RoleId { get; set; }

        protected override bool EqualsCore(StaffRole other)
        {
            return other.StaffId == this.StaffId && other.RoleId == this.RoleId && other.RoleId != Guid.Empty && other.StaffId != Guid.Empty;
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
