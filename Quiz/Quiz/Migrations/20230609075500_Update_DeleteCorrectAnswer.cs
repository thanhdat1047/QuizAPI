using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class Update_DeleteCorrectAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectAnswer");

            migrationBuilder.RenameColumn(
                name: "IsPass",
                table: "DetailUserSessions",
                newName: "IsCorrect");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "UserSession",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "UserSession",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "NumCorrectAnswer",
                table: "UserSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserSessionId",
                table: "UserSession",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Answers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Answers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCorrect",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumCorrectAnswer",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "UserSessionId",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "isCorrect",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "DetailUserSessions",
                newName: "IsPass");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "UserSession",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "UserSession",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "CorrectAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectAnswer_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectAnswer_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswer_AnswerId",
                table: "CorrectAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswer_QuestionId",
                table: "CorrectAnswer",
                column: "QuestionId");
        }
    }
}
