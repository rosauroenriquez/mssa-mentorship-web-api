﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAMentorshipCompanionWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudIdOnGoalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MentorshipId",
                table: "Goals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Goals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "MentorshipId",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
