using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Infra.Data.Map
{
    /// <summary>
    /// 员工表配置
    /// </summary>
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("sys_staff");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => x.DelFlag == 0);
            //实体属性Map
            builder.Property(c => c.Id)
                .HasColumnType("varchar(64)")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.NickName)
                .HasColumnType("varchar(64)")
                .HasColumnName("nick_name")
                .IsRequired();

            builder.Property(c => c.StaffType)
                .HasColumnName("staff_type")
                .IsRequired();

            builder.Property(c => c.Account)
                .HasColumnType("varchar(64)")
                .HasColumnName("account")
                .IsRequired();

            builder.Property(c => c.Password)
                .HasColumnType("varchar(64)")
                .HasColumnName("password")
                .IsRequired();

            builder.Property(c => c.OfficeId)
                .HasColumnType("varchar(64)")
                .HasColumnName("office_id")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(64)")
                .HasColumnName("email")
                .IsRequired();

            builder.Property(c => c.Mobile)
                .HasColumnType("varchar(16)")
                .HasColumnName("mobile")
                .IsRequired();

            builder.Property(c => c.State)
                .HasColumnName("state")
                .IsRequired();

            builder.Property(c => c.CreateBy)
                .HasColumnType("varchar(64)")
                .HasColumnName("create_by")
                .IsRequired();

            builder.Property(c => c.CreateDate)
                .HasColumnName("create_date")
                .IsRequired();


            builder.Property(c => c.UpdateBy)
                .HasColumnType("varchar(64)")
                .HasColumnName("update_by");

            builder.Property(c => c.UpdateDate)
                .HasColumnName("update_date");

            builder.Property(c => c.Remark)
                .HasColumnType("varchar(1024)")
                .HasColumnName("remark");

            builder.Property(c => c.DelFlag)
                .HasColumnName("del_flag")
                .IsRequired();
        }
    }
}
