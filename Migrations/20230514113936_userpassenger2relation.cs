using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbs_webApi_v2.Migrations
{
    /// <inheritdoc />
    public partial class userpassenger2relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "users",
                newName: "UserId");

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
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UserId",
                table: "users",
                newName: "User_Id");
        }
    }
}
