using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicDiary.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class GradeSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Grades",
                newName: "GradeValue");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "GradesSubjects",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "GradesSubjects");

            migrationBuilder.RenameColumn(
                name: "GradeValue",
                table: "Grades",
                newName: "grade");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
