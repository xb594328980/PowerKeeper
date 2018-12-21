using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerKeeper.Infra.Data.Migrations.SQLEventStore
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventStore",
                columns: table => new
                {
                    Action = table.Column<string>(type: "varchar(100)", nullable: true),
                    AggregateId = table.Column<byte[]>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<byte[]>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStore", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventStore");
        }
    }
}
