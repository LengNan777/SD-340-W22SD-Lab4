using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_340_W22SD_Lab4.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RampAccessible = table.Column<bool>(type: "bit", nullable: false),
                    BicycleAccessible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledStop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopNumber = table.Column<int>(type: "int", nullable: false),
                    RoutenNumber = table.Column<int>(type: "int", nullable: false),
                    ScheduledArrival = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledStop_Route",
                        column: x => x.RoutenNumber,
                        principalTable: "Route",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_ScheduledStop_Stop",
                        column: x => x.StopNumber,
                        principalTable: "Stop",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledStop_RoutenNumber",
                table: "ScheduledStop",
                column: "RoutenNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledStop_StopNumber",
                table: "ScheduledStop",
                column: "StopNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledStop");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Stop");
        }
    }
}
