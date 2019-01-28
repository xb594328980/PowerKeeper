﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Data.Map
{
    /// <summary>
    /// 组织机构数据表映射
    /// </summary>
    public class OfficeMap : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasQueryFilter(post => EF.Property<int>(post, "DelFlag") == 0);//设置查询自动添加DelFlag为0的条件
            builder.ToTable("sys_office");
            builder.HasKey(x => x.Id);
            //实体属性Map
            builder.Property(c => c.Id)
                .HasColumnType("varchar(64)")
                .HasColumnName("id");

            builder.Property(c => c.OfficeName)
                .HasColumnType("varchar(64)")
                .HasColumnName("office_name")
                .IsRequired();

            builder.Property(c => c.OfficePhone)
                .HasColumnType("varchar(64)")
                .HasColumnName("office_phone");

            builder.Property(c => c.OfficeCode)
                .HasColumnType("varchar(64)")
                .HasColumnName("office_code");

            builder.Property(c => c.OfficeType)
                .HasColumnName("office_type")
                .IsRequired();

            builder.Property(c => c.ParentId)
                .HasColumnType("varchar(64)")
                .HasColumnName("parent_id")
                .IsRequired();

            builder.Property(c => c.ParentIds)
                .HasColumnType("varchar(2000)")
                .HasColumnName("parent_ids")
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
