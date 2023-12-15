using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneToManyRelationBetweenUsersAndEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialEvents_CommercialUsers_CommercialUserId",
                table: "CommercialEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserEvents",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvents_UserId",
                table: "UserEvents",
                newName: "IX_UserEvents_CreatorId");

            migrationBuilder.RenameColumn(
                name: "CommercialUserId",
                table: "CommercialEvents",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_CommercialEvents_CommercialUserId",
                table: "CommercialEvents",
                newName: "IX_CommercialEvents_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialEvents_CommercialUsers_CreatorId",
                table: "CommercialEvents",
                column: "CreatorId",
                principalTable: "CommercialUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Users_CreatorId",
                table: "UserEvents",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialEvents_CommercialUsers_CreatorId",
                table: "CommercialEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Users_CreatorId",
                table: "UserEvents");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "UserEvents",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvents_CreatorId",
                table: "UserEvents",
                newName: "IX_UserEvents_UserId");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "CommercialEvents",
                newName: "CommercialUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommercialEvents_CreatorId",
                table: "CommercialEvents",
                newName: "IX_CommercialEvents_CommercialUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialEvents_CommercialUsers_CommercialUserId",
                table: "CommercialEvents",
                column: "CommercialUserId",
                principalTable: "CommercialUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
