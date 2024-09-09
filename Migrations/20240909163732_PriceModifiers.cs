using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABP_ConferenceBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class PriceModifiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingHalls_HallConferences_hallConferenceId",
                table: "bookingHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHallServiceConference_bookingHalls_bookingHallsId",
                table: "BookingHallServiceConference");

            migrationBuilder.DropCheckConstraint(
                name: "ValidDate1",
                table: "PriceModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookingHalls",
                table: "bookingHalls");

            migrationBuilder.RenameTable(
                name: "bookingHalls",
                newName: "BookingHalls");

            migrationBuilder.RenameIndex(
                name: "IX_bookingHalls_hallConferenceId",
                table: "BookingHalls",
                newName: "IX_BookingHalls_hallConferenceId");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "dateStart",
                table: "PriceModifiers",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "dateEnd",
                table: "PriceModifiers",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingHalls",
                table: "BookingHalls",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "ValidDate1",
                table: "PriceModifiers",
                sql: "[dateStart] < [dateEnd]");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHalls_HallConferences_hallConferenceId",
                table: "BookingHalls",
                column: "hallConferenceId",
                principalTable: "HallConferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHallServiceConference_BookingHalls_bookingHallsId",
                table: "BookingHallServiceConference",
                column: "bookingHallsId",
                principalTable: "BookingHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHalls_HallConferences_hallConferenceId",
                table: "BookingHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHallServiceConference_BookingHalls_bookingHallsId",
                table: "BookingHallServiceConference");

            migrationBuilder.DropCheckConstraint(
                name: "ValidDate1",
                table: "PriceModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingHalls",
                table: "BookingHalls");

            migrationBuilder.RenameTable(
                name: "BookingHalls",
                newName: "bookingHalls");

            migrationBuilder.RenameIndex(
                name: "IX_BookingHalls_hallConferenceId",
                table: "bookingHalls",
                newName: "IX_bookingHalls_hallConferenceId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateStart",
                table: "PriceModifiers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateEnd",
                table: "PriceModifiers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookingHalls",
                table: "bookingHalls",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "ValidDate1",
                table: "PriceModifiers",
                sql: "[dateStart] > '2024-09-07 00:00:00' AND [dateStart] < [dateEnd]");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingHalls_HallConferences_hallConferenceId",
                table: "bookingHalls",
                column: "hallConferenceId",
                principalTable: "HallConferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHallServiceConference_bookingHalls_bookingHallsId",
                table: "BookingHallServiceConference",
                column: "bookingHallsId",
                principalTable: "bookingHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
