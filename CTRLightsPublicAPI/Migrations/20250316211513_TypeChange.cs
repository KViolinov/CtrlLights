using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class TypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Busyness",
                table: "TrafficLights",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Busyness",
                table: "TrafficLights",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
