using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingForeignKey_Part2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspDeviceId",
                table: "AirQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EspDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspDevice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirQuality_EspDeviceId",
                table: "AirQuality",
                column: "EspDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirQuality_EspDevice_EspDeviceId",
                table: "AirQuality",
                column: "EspDeviceId",
                principalTable: "EspDevice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirQuality_EspDevice_EspDeviceId",
                table: "AirQuality");

            migrationBuilder.DropTable(
                name: "EspDevice");

            migrationBuilder.DropIndex(
                name: "IX_AirQuality_EspDeviceId",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "EspDeviceId",
                table: "AirQuality");
        }
    }
}
