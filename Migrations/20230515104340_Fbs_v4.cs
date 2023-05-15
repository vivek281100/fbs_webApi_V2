using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbs_webApi_v2.Migrations
{
    /// <inheritdoc />
    public partial class Fbs_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passengers_users_UserId",
                table: "passengers");

            migrationBuilder.DropIndex(
                name: "IX_passengers_UserId",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "passengers");

            migrationBuilder.RenameColumn(
                name: "Payment_Id",
                table: "payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Passenger_Id",
                table: "passengers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Flight_Id",
                table: "Flights",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Admin_Id",
                table: "Admins",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Isrunning",
                table: "Flights",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    bookingdatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "passengers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PassengerId",
                table: "Bookings",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropColumn(
                name: "Isrunning",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "payments",
                newName: "Payment_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "passengers",
                newName: "Passenger_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flights",
                newName: "Flight_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "Admin_Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_passengers_UserId",
                table: "passengers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_passengers_users_UserId",
                table: "passengers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
