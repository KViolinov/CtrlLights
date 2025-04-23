using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnErrorFix_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Busyness",
                table: "TrafficLights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Busyness",
                table: "TrafficLights",
                type: "text",
                nullable: true);
        }
    }
}
