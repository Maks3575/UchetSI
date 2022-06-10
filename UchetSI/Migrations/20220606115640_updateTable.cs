using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UchetSI.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHoldingTO",
                table: "ScheduleTOs");

            migrationBuilder.DropColumn(
                name: "IdTypeTO",
                table: "ScheduleTOs");

            migrationBuilder.DropColumn(
                name: "IdLocation",
                table: "HoldingTOs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdHoldingTO",
                table: "ScheduleTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTypeTO",
                table: "ScheduleTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLocation",
                table: "HoldingTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
