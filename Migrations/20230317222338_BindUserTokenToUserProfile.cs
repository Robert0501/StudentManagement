using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class BindUserTokenToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_UserProfile_UserProfileId",
                table: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_UserToken_UserProfileId",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserToken");

            migrationBuilder.AddColumn<int>(
                name: "UserTokenId",
                table: "UserProfile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserTokenId",
                table: "UserProfile",
                column: "UserTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_UserToken_UserTokenId",
                table: "UserProfile",
                column: "UserTokenId",
                principalTable: "UserToken",
                principalColumn: "UserTokenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_UserToken_UserTokenId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_UserTokenId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "UserTokenId",
                table: "UserProfile");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserToken",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserProfileId",
                table: "UserToken",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_UserProfile_UserProfileId",
                table: "UserToken",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "UserProfileId");
        }
    }
}
