using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MissionLog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manifests",
                columns: table => new
                {
                    ManifestId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManifestLifeSupportSupply = table.Column<string>(nullable: true),
                    ManifestShipCargo = table.Column<string>(nullable: true),
                    ManifestWeapon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => x.ManifestId);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MissionName = table.Column<string>(nullable: true),
                    MissionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ShipId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShipName = table.Column<string>(nullable: true),
                    ShipSpecies = table.Column<string>(nullable: true),
                    ShipType = table.Column<string>(nullable: true),
                    ShipClass = table.Column<string>(nullable: true),
                    ShipCaptain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.ShipId);
                });

            migrationBuilder.CreateTable(
                name: "MissionManifest",
                columns: table => new
                {
                    MissionManifestId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MissionId = table.Column<int>(nullable: false),
                    ManifestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionManifest", x => x.MissionManifestId);
                    table.ForeignKey(
                        name: "FK_MissionManifest_Manifests_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifests",
                        principalColumn: "ManifestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionManifest_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipManifest",
                columns: table => new
                {
                    ShipManifestId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManifestId = table.Column<int>(nullable: false),
                    ShipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipManifest", x => x.ShipManifestId);
                    table.ForeignKey(
                        name: "FK_ShipManifest_Manifests_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifests",
                        principalColumn: "ManifestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipManifest_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipMission",
                columns: table => new
                {
                    ShipMissionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShipId = table.Column<int>(nullable: false),
                    MissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMission", x => x.ShipMissionId);
                    table.ForeignKey(
                        name: "FK_ShipMission_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipMission_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionManifest_ManifestId",
                table: "MissionManifest",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionManifest_MissionId",
                table: "MissionManifest",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipManifest_ManifestId",
                table: "ShipManifest",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipManifest_ShipId",
                table: "ShipManifest",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMission_MissionId",
                table: "ShipMission",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMission_ShipId",
                table: "ShipMission",
                column: "ShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionManifest");

            migrationBuilder.DropTable(
                name: "ShipManifest");

            migrationBuilder.DropTable(
                name: "ShipMission");

            migrationBuilder.DropTable(
                name: "Manifests");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
