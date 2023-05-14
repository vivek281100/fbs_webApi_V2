using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbs_webApi_v2.Migrations
{
    /// <inheritdoc />
    public partial class userpassenger4relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passengers_users_User_Id",
                table: "passengers");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "passengers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_passengers_User_Id",
                table: "passengers",
                newName: "IX_passengers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_passengers_users_UserId",
                table: "passengers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passengers_users_UserId",
                table: "passengers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "passengers",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_passengers_UserId",
                table: "passengers",
                newName: "IX_passengers_User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_passengers_users_User_Id",
                table: "passengers",
                column: "User_Id",
                principalTable: "users",
                principalColumn: "User_Id");
        }
    }
}
