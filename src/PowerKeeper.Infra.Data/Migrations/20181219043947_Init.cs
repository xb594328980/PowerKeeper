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
                    office_phone = table.Column<string>(type: "varchar(64)", nullable: true),
                    office_type = table.Column<int>(nullable: false),
                    parent_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    parent_ids = table.Column<string>(type: "varchar(2000)", nullable: false),
                    create_by = table.Column<string>(type: "varchar(64)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(64)", nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(type: "varchar(512)", nullable: true),
                    del_flag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_office", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_office");
        }
    }
}
