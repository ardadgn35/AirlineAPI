using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixTicketFlightRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId1",
                table: "Tickets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId1",
                table: "Tickets",
                column: "FlightId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId1",
                table: "Tickets",
                column: "FlightId1",
                principalTable: "Flights",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FlightId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FlightId1",
                table: "Tickets");
        }
    }
}
