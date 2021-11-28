using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBBenchmark.Migrations
{
    public partial class AddTestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resolver = table.Column<int>(type: "int", nullable: false),
                    TestType = table.Column<int>(type: "int", nullable: false),
                    Timing = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBTests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBTests");
        }
    }
}
