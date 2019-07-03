using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Migrations
{
    public partial class CourseStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Student_StudentId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Course",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_StudentId",
                table: "Course",
                newName: "IX_Course_studentId");

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentId",
                table: "CourseStudent",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Student_studentId",
                table: "Course",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Student_studentId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Course",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_studentId",
                table: "Course",
                newName: "IX_Course_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Student_StudentId",
                table: "Course",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
