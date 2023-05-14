using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbs_webApi_v2.Migrations
{
    /// <inheritdoc />
    public partial class usertablechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
