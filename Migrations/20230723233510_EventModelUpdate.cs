using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_scriptslingers_backend.Migrations
{
    /// <inheritdoc />
    public partial class EventModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFinished",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFinished",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventId",
                keyValue: 1,
                column: "isFinished",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventId",
                keyValue: 2,
                column: "isFinished",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventId",
                keyValue: 3,
                column: "isFinished",
                value: false);
        }
    }
}
