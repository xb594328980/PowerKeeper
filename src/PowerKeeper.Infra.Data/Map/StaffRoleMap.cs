using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Models;

namespace PowerKeeper.Infra.Data.Map
{
    public class StaffRoleMap : IEntityTypeConfiguration<StaffRole>
    {
        public void Configure(EntityTypeBuilder<StaffRole> builder)
        {
            builder.ToTable("sys_staff_role");
            builder.HasKey(x => new { x.StaffId, x.RoleId });

            //实体属性Map
            builder.Property(c => c.StaffId)
                .HasColumnType("varchar(64)")
                .HasColumnName("staff_id");

            builder.Property(c => c.RoleId)
                .HasColumnType("varchar(64)")
                .HasColumnName("role_id");
        }
    }
}
