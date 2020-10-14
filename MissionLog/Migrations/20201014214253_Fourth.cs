using Microsoft.EntityFrameworkCore.Migrations;

namespace MissionLog.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShipType",
                table: "Ships",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShipType",
                table: "Ships",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
