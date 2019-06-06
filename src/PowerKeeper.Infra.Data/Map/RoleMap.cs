using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Infra.Data.Map
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("sys_role");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => x.DelFlag == 0);
            //实体属性Map
            builder.Property(c => c.Id)
                .HasColumnType("varchar(64)")
                .HasColumnName("id");

            builder.Property(c => c.RoleCode)
                .HasColumnType("varchar(64)")
                .HasColumnName("role_code")
                .IsRequired();

            builder.Property(c => c.RoleName)
                .HasColumnType("varchar(32)")
                .HasColumnName("role_name");

            builder.Property(c => c.RoleType)
                .HasColumnName("role_type")
                .IsRequired();

            builder.Property(c => c.DataScope)
                .HasColumnName("data_scope")
                .IsRequired();

            builder.Property(c => c.IsEnable)
                .HasColumnName("is_enable")
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
