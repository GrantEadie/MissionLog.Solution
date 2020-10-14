using Microsoft.EntityFrameworkCore.Migrations;

namespace MissionLog.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManifestTitle",
                table: "Manifests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManifestTitle",
                table: "Manifests");
        }
    }
}
