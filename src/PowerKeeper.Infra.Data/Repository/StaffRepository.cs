using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PowerKeeper.Domain.Interfaces;
using PowerKeeper.Domain.Models;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.Repository
{
    /// <summary>
    /// 员工仓储
    /// create by xingbo 29/06/06
    /// </summary>
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        protected readonly PowerKeeperContext _Db;
        public StaffRepository(PowerKeeperContext db) : base(db)
        {
            _Db = db;
        }


        //        public Staff PowerStaff()
        //        {
        //            StringBuilder sql = new StringBuilder();
        //            sql.Append($"select * from (select s.* from sys_staff s inner join sys_office o on o.id=s.office_id) as staff");
        //            return _Db.Staff.FromSql(sql.ToString()).Where(x => x.Account == "admin").SingleOrDefault();
        //        }

        public Staff Get(Guid? id = null, string account = null, string mobile = null, string email = null)
        {
            if (!id.HasValue && string.IsNullOrWhiteSpace(account) && string.IsNullOrWhiteSpace(mobile) && string.IsNullOrWhiteSpace(email))
                throw new AggregateException("参数不能同时为空");
            return base.GetAll(x =>
                  (!id.HasValue || x.Id == id)
                  && (string.IsNullOrWhiteSpace(account) || x.Account == account)
                  && (string.IsNullOrWhiteSpace(email) || x.Email == (email))
                  && (string.IsNullOrWhiteSpace(mobile) || x.Mobile == (mobile))).SingleOrDefault();
        }

      
    }
}
