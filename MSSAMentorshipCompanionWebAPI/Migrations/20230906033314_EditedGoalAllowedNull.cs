using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAMentorshipCompanionWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditedGoalAllowedNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_ChatThreads_GoalThreadThreadId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "GoalThreadThreadId",
                table: "Goals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GoalDate",
                table: "Goals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Goals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_ChatThreads_GoalThreadThreadId",
                table: "Goals",
                column: "GoalThreadThreadId",
                principalTable: "ChatThreads",
                principalColumn: "ThreadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_ChatThreads_GoalThreadThreadId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "GoalThreadThreadId",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GoalDate",
                table: "Goals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Goals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_ChatThreads_GoalThreadThreadId",
                table: "Goals",
                column: "GoalThreadThreadId",
                principalTable: "ChatThreads",
                principalColumn: "ThreadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
