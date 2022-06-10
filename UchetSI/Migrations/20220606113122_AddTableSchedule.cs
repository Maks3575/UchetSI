using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UchetSI.Migrations
{
    public partial class AddTableSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoldingTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IdLocation = table.Column<int>(type: "int", nullable: false),
                    PeriodOfTO = table.Column<int>(type: "int", nullable: false),
                    YearEvent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingTOs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberMonth = table.Column<int>(type: "int", nullable: false),
                    PlanDataTOFrom = table.Column<int>(type: "int", nullable: true),
                    PlanDateTOTo = table.Column<int>(type: "int", nullable: true),
                    FactDateTOFrom = table.Column<int>(type: "int", nullable: true),
                    FactDateTOTo = table.Column<int>(type: "int", nullable: true),
                    IdTypeTO = table.Column<int>(type: "int", nullable: false),
                    TypeTOId = table.Column<int>(type: "int", nullable: false),
                    IdHoldingTO = table.Column<int>(type: "int", nullable: false),
                    HoldingTOId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleTOs_HoldingTOs_HoldingTOId",
                        column: x => x.HoldingTOId,
                        principalTable: "HoldingTOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleTOs_TypeTOs_TypeTOId",
                        column: x => x.TypeTOId,
                        principalTable: "TypeTOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoldingTOs_LocationId",
                table: "HoldingTOs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTOs_HoldingTOId",
                table: "ScheduleTOs",
                column: "HoldingTOId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTOs_TypeTOId",
                table: "ScheduleTOs",
                column: "TypeTOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleTOs");

            migrationBuilder.DropTable(
                name: "HoldingTOs");

            migrationBuilder.DropTable(
                name: "TypeTOs");
        }
    }
}
