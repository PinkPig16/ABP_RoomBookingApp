using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABP_ConferenceBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallConferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallConferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceModifiers", x => x.Id);
                    table.CheckConstraint("ValidDate", "[dateStart] > '2024-09-07 00:00:00' AND [dateStart] < [dateEnd]");
                });

            migrationBuilder.CreateTable(
                name: "serviceConferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceConferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HallConferenceServiceConference",
                columns: table => new
                {
                    ConferencesId = table.Column<int>(type: "int", nullable: false),
                    ServiceConferencesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallConferenceServiceConference", x => new { x.ConferencesId, x.ServiceConferencesId });
                    table.ForeignKey(
                        name: "FK_HallConferenceServiceConference_HallConferences_ConferencesId",
                        column: x => x.ConferencesId,
                        principalTable: "HallConferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HallConferenceServiceConference_serviceConferences_ServiceConferencesId",
                        column: x => x.ServiceConferencesId,
                        principalTable: "serviceConferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HallConferenceServiceConference_ServiceConferencesId",
                table: "HallConferenceServiceConference",
                column: "ServiceConferencesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallConferenceServiceConference");

            migrationBuilder.DropTable(
                name: "PriceModifiers");

            migrationBuilder.DropTable(
                name: "HallConferences");

            migrationBuilder.DropTable(
                name: "serviceConferences");
        }
    }
}
