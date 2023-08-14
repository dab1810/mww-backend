using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_scriptslingers_backend.Migrations
{
    /// <inheritdoc />
    public partial class updated3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Posts",
                newName: "postContent");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "postId");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Comments",
                newName: "commentContent");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                newName: "IX_Comments_postId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "postContent",
                table: "Posts",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "commentContent",
                table: "Comments",
                newName: "content");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_postId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
