using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABP_ConferenceBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class changeServiceConference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "serviceConferences",
                type: "decimal(12,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "serviceConferences");
        }
    }
}
