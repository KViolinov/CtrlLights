using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "TrafficLights");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RecordedAt",
                table: "TrafficLights",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordedAt",
                table: "TrafficLights");

            migrationBuilder.AddColumn<int>(
                name: "TimeSpan",
                table: "TrafficLights",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
