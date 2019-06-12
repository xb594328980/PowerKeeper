﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerKeeper.Infra.Data.Context;

namespace PowerKeeper.Infra.Data.Migrations
{
    [DbContext(typeof(PowerKeeperContext))]
    [Migration("20190611051945_update_19_06_11_1302")]
    partial class update_19_06_11_1302
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PowerKeeper.Domain.Models.Office", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("create_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date");

                    b.Property<int>("DelFlag")
                        .HasColumnName("del_flag");

                    b.Property<string>("OfficeCode")
                        .HasColumnName("office_code")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnName("office_name")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("OfficePhone")
                        .HasColumnName("office_phone")
                        .HasColumnType("varchar(32)");

                    b.Property<int>("OfficeType")
                        .HasColumnName("office_type");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("parent_id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ParentIds")
                        .IsRequired()
                        .HasColumnName("parent_ids")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Remark")
                        .HasColumnName("remark")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("UpdateBy")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("update_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("sys_office");
                });

            modelBuilder.Entity("PowerKeeper.Domain.Models.Resource", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("create_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date");

                    b.Property<int>("DelFlag")
                        .HasColumnName("del_flag");

                    b.Property<string>("InterfaceUrl")
                        .HasColumnName("interface_url")
                        .HasColumnType("varchar(128)");

                    b.Property<int>("IsEnable")
                        .HasColumnName("is_enable");

                    b.Property<int>("IsShow")
                        .HasColumnName("is_enable");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("parent_id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ParentIds")
                        .IsRequired()
                        .HasColumnName("parent_ids")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Remark")
                        .HasColumnName("remark")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("ResourceCode")
                        .IsRequired()
                        .HasColumnName("resource_code")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ResourceIcon")
                        .HasColumnName("resource_icon")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ResourceName")
                        .HasColumnName("resource_name")
                        .HasColumnType("varchar(64)");

                    b.Property<int>("ResourceType")
                        .HasColumnName("resource_type");

                    b.Property<string>("ResourceUrl")
                        .HasColumnName("resource_url")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ShowName");

                    b.Property<string>("UpdateBy")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("update_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("sys_resource");
                });

            modelBuilder.Entity("PowerKeeper.Domain.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("create_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date");

                    b.Property<int>("DataScope")
                        .HasColumnName("data_scope");

                    b.Property<int>("DelFlag")
                        .HasColumnName("del_flag");

                    b.Property<int>("IsEnable")
                        .HasColumnName("is_enable");

                    b.Property<string>("Remark")
                        .HasColumnName("remark")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasColumnName("role_code")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("RoleName")
                        .HasColumnName("role_name")
                        .HasColumnType("varchar(32)");

                    b.Property<int>("RoleType")
                        .HasColumnName("role_type");

                    b.Property<string>("UpdateBy")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("update_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("sys_role");
                });

            modelBuilder.Entity("PowerKeeper.Domain.Models.Staff", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnName("account")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("create_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date");

                    b.Property<int>("DelFlag")
                        .HasColumnName("del_flag");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnName("mobile")
                        .HasColumnType("varchar(16)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnName("nick_name")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("OfficeId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("office_id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Remark")
                        .HasColumnName("remark")
                        .HasColumnType("varchar(1024)");

                    b.Property<int>("StaffType")
                        .HasColumnName("staff_type");

                    b.Property<int>("State")
                        .HasColumnName("state");

                    b.Property<string>("UpdateBy")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("update_by")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("sys_staff");
                });

            modelBuilder.Entity("PowerKeeper.Domain.Models.StaffRole", b =>
                {
                    b.Property<string>("StaffId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("staff_id")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("RoleId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnName("role_id")
                        .HasColumnType("varchar(64)");

                    b.HasKey("StaffId", "RoleId");

                    b.HasAlternateKey("RoleId", "StaffId");

                    b.ToTable("sys_staff_role");
                });
#pragma warning restore 612, 618
        }
    }
}
