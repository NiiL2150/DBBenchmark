using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBBenchmark.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstValue = table.Column<int>(type: "int", nullable: false),
                    SecondValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdValue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FourthValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomValues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomValues");
        }
    }
}
