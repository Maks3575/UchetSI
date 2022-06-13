using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UchetSI.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DescriptionOfEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionOfEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMaker = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowerLimit = table.Column<float>(type: "real", nullable: false),
                    UpperLimit = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementLimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutputSignals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOutputSignal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputSignals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOfMTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOfMTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypelocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLocations", x => x.Id);
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
                name: "UnitOfMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationInterval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationInterval", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeOfEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakerId = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfEquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfEquipments_DescriptionOfEquipments_DescriptionOfEquipmentId",
                        column: x => x.DescriptionOfEquipmentId,
                        principalTable: "DescriptionOfEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeOfEquipments_Makers_MakerId",
                        column: x => x.MakerId,
                        principalTable: "Makers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    TypeLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_TypeLocations_TypeLocationId",
                        column: x => x.TypeLocationId,
                        principalTable: "TypeLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionMIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    outputSignalId = table.Column<int>(type: "int", nullable: false),
                    MeasurementLimitId = table.Column<int>(type: "int", nullable: false),
                    VerificationIntervalId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false),
                    TypeOfEquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionMIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionMIs_MeasurementLimits_MeasurementLimitId",
                        column: x => x.MeasurementLimitId,
                        principalTable: "MeasurementLimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionMIs_OutputSignals_outputSignalId",
                        column: x => x.outputSignalId,
                        principalTable: "OutputSignals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionMIs_TypeOfEquipments_TypeOfEquipmentId",
                        column: x => x.TypeOfEquipmentId,
                        principalTable: "TypeOfEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionMIs_UnitOfMeasurements_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "UnitOfMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionMIs_VerificationInterval_VerificationIntervalId",
                        column: x => x.VerificationIntervalId,
                        principalTable: "VerificationInterval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoldingTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PeriodOfTO = table.Column<int>(type: "int", nullable: true),
                    YearEvent = table.Column<int>(type: "int", nullable: true)
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
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paz = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    NameParameter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeashuringTools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionMIId = table.Column<int>(type: "int", nullable: false),
                    StatusOfMTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeashuringTools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeashuringTools_DescriptionMIs_DescriptionMIId",
                        column: x => x.DescriptionMIId,
                        principalTable: "DescriptionMIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeashuringTools_StatusOfMTs_StatusOfMTId",
                        column: x => x.StatusOfMTId,
                        principalTable: "StatusOfMTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberMonth = table.Column<int>(type: "int", nullable: true),
                    PlanDataTOFrom = table.Column<int>(type: "int", nullable: true),
                    PlanDateTOTo = table.Column<int>(type: "int", nullable: true),
                    FactDateTOFrom = table.Column<int>(type: "int", nullable: true),
                    FactDateTOTo = table.Column<int>(type: "int", nullable: true),
                    TypeTOId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    MeashuringToolId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_MeashuringTools_MeashuringToolId",
                        column: x => x.MeashuringToolId,
                        principalTable: "MeashuringTools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Histories_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Histories_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionMIs_MeasurementLimitId",
                table: "DescriptionMIs",
                column: "MeasurementLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionMIs_outputSignalId",
                table: "DescriptionMIs",
                column: "outputSignalId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionMIs_TypeOfEquipmentId",
                table: "DescriptionMIs",
                column: "TypeOfEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionMIs_UnitOfMeasurementId",
                table: "DescriptionMIs",
                column: "UnitOfMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionMIs_VerificationIntervalId",
                table: "DescriptionMIs",
                column: "VerificationIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_MeashuringToolId",
                table: "Histories",
                column: "MeashuringToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_PositionId",
                table: "Histories",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_StatusId",
                table: "Histories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingTOs_LocationId",
                table: "HoldingTOs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParentId",
                table: "Locations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TypeLocationId",
                table: "Locations",
                column: "TypeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeashuringTools_DescriptionMIId",
                table: "MeashuringTools",
                column: "DescriptionMIId");

            migrationBuilder.CreateIndex(
                name: "IX_MeashuringTools_StatusOfMTId",
                table: "MeashuringTools",
                column: "StatusOfMTId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_LocationId",
                table: "Positions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTOs_HoldingTOId",
                table: "ScheduleTOs",
                column: "HoldingTOId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTOs_TypeTOId",
                table: "ScheduleTOs",
                column: "TypeTOId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfEquipments_DescriptionOfEquipmentId",
                table: "TypeOfEquipments",
                column: "DescriptionOfEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfEquipments_MakerId",
                table: "TypeOfEquipments",
                column: "MakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "ScheduleTOs");

            migrationBuilder.DropTable(
                name: "MeashuringTools");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "HoldingTOs");

            migrationBuilder.DropTable(
                name: "TypeTOs");

            migrationBuilder.DropTable(
                name: "DescriptionMIs");

            migrationBuilder.DropTable(
                name: "StatusOfMTs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MeasurementLimits");

            migrationBuilder.DropTable(
                name: "OutputSignals");

            migrationBuilder.DropTable(
                name: "TypeOfEquipments");

            migrationBuilder.DropTable(
                name: "UnitOfMeasurements");

            migrationBuilder.DropTable(
                name: "VerificationInterval");

            migrationBuilder.DropTable(
                name: "TypeLocations");

            migrationBuilder.DropTable(
                name: "DescriptionOfEquipments");

            migrationBuilder.DropTable(
                name: "Makers");
        }
    }
}
