using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamespaceGPT_ASP.NET_Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnmappedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaqIds",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "ManagerUsernames",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "PostIds",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "ReviewIds",
                table: "Business");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Business",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Business");

            migrationBuilder.AddColumn<string>(
                name: "FaqIds",
                table: "Business",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "ManagerUsernames",
                table: "Business",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "PostIds",
                table: "Business",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "ReviewIds",
                table: "Business",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);
        }
    }
}
