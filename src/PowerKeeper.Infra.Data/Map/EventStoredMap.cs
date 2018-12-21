using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerKeeper.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Data.Map
{
    /// <summary>
    /// 事件存储模型Map
    /// <remarks>create by xingbo 18/12/20</remarks>
    /// </summary>
    public class StoredEventMap : IEntityTypeConfiguration<EventStore>
    {
        public void Configure(EntityTypeBuilder<EventStore> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}
