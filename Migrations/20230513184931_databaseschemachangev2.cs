using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbs_webApi_v2.Migrations
{
    /// <inheritdoc />
    public partial class databaseschemachangev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seatAllocateds");

            migrationBuilder.DropTable(
                name: "seatsAvailables");

            migrationBuilder.DropColumn(
                name: "ArrivalDateTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureDateTime",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "DipartureCityCode",
                table: "Flights",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalCityCode",
                table: "Flights",
                newName: "ArrivalCity");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalDate",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTime",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureCity",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureDate",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalNoofseats",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TotalNoofseats",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Flights",
                newName: "DipartureCityCode");

            migrationBuilder.RenameColumn(
                name: "ArrivalCity",
                table: "Flights",
                newName: "ArrivalCityCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDateTime",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "seatAllocateds",
                columns: table => new
                {
                    Seat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seat_Allocated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seatAllocateds", x => x.Seat_Id);
                });

            migrationBuilder.CreateTable(
                name: "seatsAvailables",
                columns: table => new
                {
                    SeatsAvailable_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalNoOfSeats = table.Column<int>(type: "int", nullable: false),
                    seatsAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seatsAvailables", x => x.SeatsAvailable_Id);
                });
        }
    }
}
