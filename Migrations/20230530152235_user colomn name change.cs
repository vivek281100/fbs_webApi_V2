using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbs_webApi_v2.Migrations
{
    /// <inheritdoc />
    public partial class usercolomnnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Name",
                table: "users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "User_Name");
        }
    }
}
