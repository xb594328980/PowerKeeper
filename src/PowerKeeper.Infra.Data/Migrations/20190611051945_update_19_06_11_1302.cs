using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerKeeper.Infra.Data.Migrations
{
    public partial class update_19_06_11_1302 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_staff_role",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    role_id = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_staff_role", x => new { x.staff_id, x.role_id });
                    table.UniqueConstraint("AK_sys_staff_role_role_id_staff_id", x => new { x.role_id, x.staff_id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_staff_role");
        }
    }
}
