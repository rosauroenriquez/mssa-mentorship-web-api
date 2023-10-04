using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAMentorshipCompanionWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentMentorIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Mentorships",
                type: "nvarchar(50)",
                nullable: false);
            migrationBuilder.AddColumn<string>(
                name: "MentorId",
                table: "Mentorships",
                type: "nvarchar(50)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Mentorships");
            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Mentorships");
        }
    }
}
