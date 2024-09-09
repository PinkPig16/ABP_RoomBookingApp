using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABP_ConferenceBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class bookingConference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ValidDate",
                table: "PriceModifiers");

            migrationBuilder.CreateTable(
                name: "bookingHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hallConferenceId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingHalls", x => x.Id);
                    table.CheckConstraint("ValidDate", "[startTime] < [endTime]");
                    table.ForeignKey(
                        name: "FK_bookingHalls_HallConferences_hallConferenceId",
                        column: x => x.hallConferenceId,
                        principalTable: "HallConferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHallServiceConference",
                columns: table => new
                {
                    ServiceConferencesId = table.Column<int>(type: "int", nullable: false),
                    bookingHallsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHallServiceConference", x => new { x.ServiceConferencesId, x.bookingHallsId });
                    table.ForeignKey(
                        name: "FK_BookingHallServiceConference_bookingHalls_bookingHallsId",
                        column: x => x.bookingHallsId,
                        principalTable: "bookingHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingHallServiceConference_serviceConferences_ServiceConferencesId",
                        column: x => x.ServiceConferencesId,
                        principalTable: "serviceConferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "ValidDate1",
                table: "PriceModifiers",
                sql: "[dateStart] > '2024-09-07 00:00:00' AND [dateStart] < [dateEnd]");

            migrationBuilder.CreateIndex(
                name: "IX_bookingHalls_hallConferenceId",
                table: "bookingHalls",
                column: "hallConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHallServiceConference_bookingHallsId",
                table: "BookingHallServiceConference",
                column: "bookingHallsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingHallServiceConference");

            migrationBuilder.DropTable(
                name: "bookingHalls");

            migrationBuilder.DropCheckConstraint(
                name: "ValidDate1",
                table: "PriceModifiers");

            migrationBuilder.AddCheckConstraint(
                name: "ValidDate",
                table: "PriceModifiers",
                sql: "[dateStart] > '2024-09-07 00:00:00' AND [dateStart] < [dateEnd]");
        }
    }
}
