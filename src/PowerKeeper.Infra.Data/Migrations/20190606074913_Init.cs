using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerKeeper.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_office",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(64)", nullable: false),
                    office_name = table.Column<string>(type: "varchar(64)", nullable: false),
                    office_code = table.Column<string>(type: "varchar(64)", nullable: true),
                    office_phone = table.Column<string>(type: "varchar(32)", nullable: true),
                    office_type = table.Column<int>(nullable: false),
                    parent_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    parent_ids = table.Column<string>(type: "varchar(1024)", nullable: false),
                    create_by = table.Column<string>(type: "varchar(64)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(64)", nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(type: "varchar(1024)", nullable: true),
                    del_flag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_office", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_resource",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(64)", nullable: false),
                    parent_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    parent_ids = table.Column<string>(type: "varchar(1024)", nullable: false),
                    resource_type = table.Column<int>(nullable: false),
                    resource_name = table.Column<string>(type: "varchar(64)", nullable: true),
                    resource_code = table.Column<string>(type: "varchar(64)", nullable: false),
                    ShowName = table.Column<string>(nullable: true),
                    resource_url = table.Column<string>(type: "varchar(128)", nullable: true),
                    interface_url = table.Column<string>(type: "varchar(128)", nullable: true),
                    resource_icon = table.Column<string>(type: "varchar(64)", nullable: true),
                    is_enable = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(type: "varchar(64)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(64)", nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(type: "varchar(1024)", nullable: true),
                    del_flag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(64)", nullable: false),
                    role_type = table.Column<int>(nullable: false),
                    data_scope = table.Column<int>(nullable: false),
                    role_name = table.Column<string>(type: "varchar(32)", nullable: true),
                    role_code = table.Column<string>(type: "varchar(64)", nullable: false),
                    is_enable = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(type: "varchar(64)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(64)", nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(type: "varchar(1024)", nullable: true),
                    del_flag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_staff",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(64)", nullable: false),
                    staff_type = table.Column<int>(nullable: false),
                    nick_name = table.Column<string>(type: "varchar(64)", nullable: false),
                    account = table.Column<string>(type: "varchar(64)", nullable: false),
                    password = table.Column<string>(type: "varchar(64)", nullable: false),
                    office_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    mobile = table.Column<string>(type: "varchar(16)", nullable: false),
                    email = table.Column<string>(type: "varchar(64)", nullable: false),
                    state = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(type: "varchar(64)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(64)", nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(type: "varchar(1024)", nullable: true),
                    del_flag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_staff", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_office");

            migrationBuilder.DropTable(
                name: "sys_resource");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_staff");
        }
    }
}
