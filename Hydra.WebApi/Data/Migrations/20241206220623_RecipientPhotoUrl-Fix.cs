using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.WebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecipientPhotoUrlFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");
        }
    }
}
