using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Infra.Data.Map
{
    public class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("sys_resource");
            builder.HasKey(x => x.Id);
            //实体属性Map
            builder.Property(c => c.Id)
                .HasColumnType("varchar(64)")
                .HasColumnName("id");

            builder.Property(c => c.ResourceCode)
                .HasColumnType("varchar(64)")
                .HasColumnName("resource_code")
                .IsRequired();

            builder.Property(c => c.ResourceName)
                .HasColumnType("varchar(64)")
                .HasColumnName("resource_name");

            builder.Property(c => c.ResourceUrl)
                .HasColumnType("varchar(128)")
                .HasColumnName("resource_url");

            builder.Property(c => c.ResourceType)
                .HasColumnName("resource_type")
                .IsRequired();

            builder.Property(c => c.InterfaceUrl)
                .HasColumnType("varchar(128)")
                .HasColumnName("interface_url");

            builder.Property(c => c.ResourceIcon)
                .HasColumnType("varchar(64)")
                .HasColumnName("resource_icon");

            builder.Property(c => c.ParentId)
                .HasColumnType("varchar(64)")
                .HasColumnName("parent_id")
                .IsRequired();

            builder.Property(c => c.ParentIds)
                .HasColumnType("varchar(1024)")
                .HasColumnName("parent_ids")
                .IsRequired();


            builder.Property(c => c.IsShow)
                .HasColumnName("is_enable")
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
