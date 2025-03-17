using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class TableNamesChanges_Part1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspDevice_airquality_AirQualityId",
                table: "EspDevice");

            migrationBuilder.DropTable(
                name: "trafficlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_airquality",
                table: "airquality");

            migrationBuilder.RenameTable(
                name: "airquality",
                newName: "AirQuality");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirQuality",
                table: "AirQuality",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EspDevice_AirQuality_AirQualityId",
                table: "EspDevice",
                column: "AirQualityId",
                principalTable: "AirQuality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspDevice_AirQuality_AirQualityId",
                table: "EspDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AirQuality",
                table: "AirQuality");

            migrationBuilder.RenameTable(
                name: "AirQuality",
                newName: "airquality");

            migrationBuilder.AddPrimaryKey(
                name: "PK_airquality",
                table: "airquality",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "trafficlights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FreeLaneStatus = table.Column<string>(type: "text", nullable: false),
                    Lane = table.Column<int>(type: "integer", nullable: false),
                    LightStatus = table.Column<char>(type: "character(1)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TimeSpan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trafficlights", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EspDevice_airquality_AirQualityId",
                table: "EspDevice",
                column: "AirQualityId",
                principalTable: "airquality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
