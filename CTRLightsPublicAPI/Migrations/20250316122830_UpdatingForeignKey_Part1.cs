using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingForeignKey_Part1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspDevice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AirQualityId = table.Column<int>(type: "integer", nullable: false),
                    MacAddress = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspDevice_AirQuality_AirQualityId",
                        column: x => x.AirQualityId,
                        principalTable: "AirQuality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspDevice_AirQualityId",
                table: "EspDevice",
                column: "AirQualityId");
        }
    }
}
