using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class Add_SessionandDetailSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailUserSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUserAnswer = table.Column<int>(type: "int", nullable: false),
                    IdQuestion = table.Column<int>(type: "int", nullable: false),
                    IdUserSession = table.Column<int>(type: "int", nullable: false),
                    IsPass = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailUserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailUserSessions_UserSession_IdUserSession",
                        column: x => x.IdUserSession,
                        principalTable: "UserSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailUserSessions_IdUserSession",
                table: "DetailUserSessions",
                column: "IdUserSession");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailUserSessions");

            migrationBuilder.DropTable(
                name: "UserSession");
        }
    }
}
