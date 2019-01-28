using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Infra.Data.Map
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasQueryFilter(post => EF.Property<int>(post, "DelFlag") == 0);//设置查询自动添加DelFlag为0的条件
            builder.ToTable("sys_staff");//设置表名
            builder.HasKey(x => x.Id);//设置主键
            //实体属性Map
            builder.Property(c => c.Id)
                .HasColumnType("varchar(64)")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.StaffName)
                .HasColumnType("varchar(64)")
                .HasColumnName("staff_name")
                .IsRequired();

            builder.Property(c => c.Mobile)
                .HasColumnType("varchar(64)")
                .HasColumnName("mobile")
                .IsRequired();

            builder.Property(c => c.Account)
                          .HasColumnType("varchar(64)")
                          .HasColumnName("account")
                          .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(64)")
                .HasColumnName("email");

            builder.Property(c => c.StaffType)
                .HasColumnName("staff_type")
                .IsRequired();

            builder.Property(c => c.OfficeId)
                .HasColumnType("varchar(64)")
                .HasColumnName("office_id")
                .IsRequired();

            builder.Property(c => c.EnabledFlag)
                .HasColumnName("enabled_flag")
                .IsRequired();

            builder.Property(c => c.LoginFlag)
                .HasColumnName("login_flag")
                .IsRequired();

            builder.Property(c => c.CreateBy)
                .HasColumnType("varchar(64)")
                .HasColumnName("create_by")
                .IsRequired();

            builder.Property(c => c.DelFlag)
                .HasColumnName("del_flag")
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
                .HasColumnType("varchar(512)")
                .HasColumnName("remark");
        }
    }
}
