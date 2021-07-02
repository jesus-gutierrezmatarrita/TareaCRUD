using Microsoft.EntityFrameworkCore.Migrations;

namespace TareaCRUD.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modalidad",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseId",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Course_CourseId",
                table: "Course",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Course_CourseId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Modalidad",
                table: "Course");
        }
    }
}
