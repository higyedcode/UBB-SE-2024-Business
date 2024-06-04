using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamespaceGPT_ASP.NET_Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCommentIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentIds",
                table: "Post");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentIds",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);
        }
    }
}
