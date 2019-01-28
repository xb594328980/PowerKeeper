using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerKeeper.Infra.Data.Migrations
{
    public partial class update_19_01_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_staff",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(64)", nullable: false),
                    staff_name = table.Column<string>(type: "varchar(64)", nullable: false),
                    staff_type = table.Column<int>(nullable: false),
                    office_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    Account = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(type: "varchar(64)", nullable: false),
                    email = table.Column<string>(type: "varchar(64)", nullable: true),
                    enabled_flag = table.Column<int>(nullable: false),
                    login_flag = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(type: "varchar(64)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(64)", nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(type: "varchar(512)", nullable: true),
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
                name: "sys_staff");
        }
    }
}
