using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationProjectV2.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFlightDetails",
                columns: table => new
                {
                    UserFlightDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFlightDetails", x => x.UserFlightDetailId);
                });

            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    FlightDeatailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departuretime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfreturnTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserFlightDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.FlightDeatailId);
                    table.ForeignKey(
                        name: "FK_FlightDetails_UserFlightDetails_UserFlightDetailId",
                        column: x => x.UserFlightDetailId,
                        principalTable: "UserFlightDetails",
                        principalColumn: "UserFlightDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserFlightDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserDetailId);
                    table.ForeignKey(
                        name: "FK_UserDetails_UserFlightDetails_UserFlightDetailId",
                        column: x => x.UserFlightDetailId,
                        principalTable: "UserFlightDetails",
                        principalColumn: "UserFlightDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityDetails",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FlightDeatailId = table.Column<int>(type: "int", nullable: false),
                    FlightDetailFlightDeatailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDetails", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityDetails_FlightDetails_FlightDetailFlightDeatailId",
                        column: x => x.FlightDetailFlightDeatailId,
                        principalTable: "FlightDetails",
                        principalColumn: "FlightDeatailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaneDetails",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlaneDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FlightDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneDetails", x => x.PlaneId);
                    table.ForeignKey(
                        name: "FK_PlaneDetails_FlightDetails_FlightDetailId",
                        column: x => x.FlightDetailId,
                        principalTable: "FlightDetails",
                        principalColumn: "FlightDeatailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatDetails",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlaneDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatDetails", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_SeatDetails_PlaneDetails_PlaneDetailId",
                        column: x => x.PlaneDetailId,
                        principalTable: "PlaneDetails",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityDetails_FlightDetailFlightDeatailId",
                table: "CityDetails",
                column: "FlightDetailFlightDeatailId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_UserFlightDetailId",
                table: "FlightDetails",
                column: "UserFlightDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneDetails_FlightDetailId",
                table: "PlaneDetails",
                column: "FlightDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatDetails_PlaneDetailId",
                table: "SeatDetails",
                column: "PlaneDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserFlightDetailId",
                table: "UserDetails",
                column: "UserFlightDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityDetails");

            migrationBuilder.DropTable(
                name: "SeatDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "PlaneDetails");

            migrationBuilder.DropTable(
                name: "FlightDetails");

            migrationBuilder.DropTable(
                name: "UserFlightDetails");
        }
    }
}
