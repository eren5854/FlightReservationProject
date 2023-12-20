using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationV3.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_City1Id",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_City1Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "City1Id",
                table: "Flights");

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "City1Id",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_City1Id",
                table: "Flights",
                column: "City1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_City1Id",
                table: "Flights",
                column: "City1Id",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
