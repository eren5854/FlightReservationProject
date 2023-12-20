using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationV3.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Seat_SeatId",
                table: "Planes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlight_AspNetUsers_UserId",
                table: "UserFlight");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlight_Flights_FlightId",
                table: "UserFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFlight",
                table: "UserFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "UserFlight",
                newName: "UserFlights");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_UserFlight_UserId",
                table: "UserFlights",
                newName: "IX_UserFlights_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFlight_FlightId",
                table: "UserFlights",
                newName: "IX_UserFlights_FlightId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Planes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "City1Id",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "City2Id",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFlights",
                table: "UserFlights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_City1Id",
                table: "Flights",
                column: "City1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_City2Id",
                table: "Flights",
                column: "City2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_City1Id",
                table: "Flights",
                column: "City1Id",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_City2Id",
                table: "Flights",
                column: "City2Id",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Seats_SeatId",
                table: "Planes",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlights_AspNetUsers_UserId",
                table: "UserFlights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlights_Flights_FlightId",
                table: "UserFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_City1Id",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_City2Id",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Seats_SeatId",
                table: "Planes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlights_AspNetUsers_UserId",
                table: "UserFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlights_Flights_FlightId",
                table: "UserFlights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_City1Id",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_City2Id",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFlights",
                table: "UserFlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "City1Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "City2Id",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "UserFlights",
                newName: "UserFlight");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_UserFlights_UserId",
                table: "UserFlight",
                newName: "IX_UserFlight_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFlights_FlightId",
                table: "UserFlight",
                newName: "IX_UserFlight_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFlight",
                table: "UserFlight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Seat_SeatId",
                table: "Planes",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlight_AspNetUsers_UserId",
                table: "UserFlight",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlight_Flights_FlightId",
                table: "UserFlight",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
