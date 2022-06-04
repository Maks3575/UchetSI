using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UchetSI.Migrations
{
    public partial class nullubl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_MeashuringTools_MeashuringToolId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Positions_PositionId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Statuses_StatusId",
                table: "Histories");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Histories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Histories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MeashuringToolId",
                table: "Histories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_MeashuringTools_MeashuringToolId",
                table: "Histories",
                column: "MeashuringToolId",
                principalTable: "MeashuringTools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Positions_PositionId",
                table: "Histories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Statuses_StatusId",
                table: "Histories",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_MeashuringTools_MeashuringToolId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Positions_PositionId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Statuses_StatusId",
                table: "Histories");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeashuringToolId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_MeashuringTools_MeashuringToolId",
                table: "Histories",
                column: "MeashuringToolId",
                principalTable: "MeashuringTools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Positions_PositionId",
                table: "Histories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Statuses_StatusId",
                table: "Histories",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
