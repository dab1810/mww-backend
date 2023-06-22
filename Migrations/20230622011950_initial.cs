using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace team_scriptslingers_backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    eventTitle = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    location = table.Column<string>(type: "TEXT", nullable: true),
                    hostName = table.Column<string>(type: "TEXT", nullable: true),
                    attendeeList = table.Column<string>(type: "TEXT", nullable: true),
                    eventTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isFinished = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.eventId);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "eventId", "attendeeList", "description", "eventTime", "eventTitle", "hostName", "isFinished", "location" },
                values: new object[,]
                {
                    { 1, null, "This is the first scheduled event on the database", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event number ONE", "David", false, null },
                    { 2, null, "This is the SECOND scheduled event on the database", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event number TWO", "Marina", false, null },
                    { 3, null, "This is the THIRD scheduled event on the database", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event number THREE", "Joseph", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
