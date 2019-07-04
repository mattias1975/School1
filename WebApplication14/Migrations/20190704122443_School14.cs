using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Migrations
{
    public partial class School14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Student_studentId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_studentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_studentId",
                table: "Course",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Student_studentId",
                table: "Course",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
