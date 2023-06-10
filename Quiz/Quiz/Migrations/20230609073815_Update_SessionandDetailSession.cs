using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class Update_SessionandDetailSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailUserSessions_UserSession_IdUserSession",
                table: "DetailUserSessions");

            migrationBuilder.DropColumn(
                name: "IdQuestion",
                table: "DetailUserSessions");

            migrationBuilder.RenameColumn(
                name: "IdUserSession",
                table: "DetailUserSessions",
                newName: "UserSessionId");

            migrationBuilder.RenameColumn(
                name: "IdUserAnswer",
                table: "DetailUserSessions",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailUserSessions_IdUserSession",
                table: "DetailUserSessions",
                newName: "IX_DetailUserSessions_UserSessionId");

            migrationBuilder.AddColumn<int>(
                name: "UserAnswerId",
                table: "DetailUserSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailUserSessions_QuestionId",
                table: "DetailUserSessions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailUserSessions_Questions_QuestionId",
                table: "DetailUserSessions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailUserSessions_UserSession_UserSessionId",
                table: "DetailUserSessions",
                column: "UserSessionId",
                principalTable: "UserSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailUserSessions_Questions_QuestionId",
                table: "DetailUserSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailUserSessions_UserSession_UserSessionId",
                table: "DetailUserSessions");

            migrationBuilder.DropIndex(
                name: "IX_DetailUserSessions_QuestionId",
                table: "DetailUserSessions");

            migrationBuilder.DropColumn(
                name: "UserAnswerId",
                table: "DetailUserSessions");

            migrationBuilder.RenameColumn(
                name: "UserSessionId",
                table: "DetailUserSessions",
                newName: "IdUserSession");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "DetailUserSessions",
                newName: "IdUserAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_DetailUserSessions_UserSessionId",
                table: "DetailUserSessions",
                newName: "IX_DetailUserSessions_IdUserSession");

            migrationBuilder.AddColumn<int>(
                name: "IdQuestion",
                table: "DetailUserSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailUserSessions_UserSession_IdUserSession",
                table: "DetailUserSessions",
                column: "IdUserSession",
                principalTable: "UserSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
