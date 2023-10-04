using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAMentorshipCompanionWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMentorshipGoalChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatThreads",
                columns: table => new
                {
                    ThreadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatThreads", x => x.ThreadId);
                });

            migrationBuilder.CreateTable(
                name: "Mentorships",
                columns: table => new
                {
                    MentorshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorships", x => x.MentorshipId);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    ChatMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatThreadThreadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatThreads_ChatThreadThreadId",
                        column: x => x.ChatThreadThreadId,
                        principalTable: "ChatThreads",
                        principalColumn: "ThreadId");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorshipId = table.Column<int>(type: "int", nullable: false),
                    GoalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalThreadThreadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goals_ChatThreads_GoalThreadThreadId",
                        column: x => x.GoalThreadThreadId,
                        principalTable: "ChatThreads",
                        principalColumn: "ThreadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatThreadThreadId",
                table: "ChatMessages",
                column: "ChatThreadThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalThreadThreadId",
                table: "Goals",
                column: "GoalThreadThreadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Mentorships");

            migrationBuilder.DropTable(
                name: "ChatThreads");
        }
    }
}
