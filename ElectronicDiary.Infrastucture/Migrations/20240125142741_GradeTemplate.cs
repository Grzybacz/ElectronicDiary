using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicDiary.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class GradeTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GradeValue",
                table: "Grades",
                newName: "GradeTemplateId");

            migrationBuilder.AddColumn<string>(
                name: "WriteGrade",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GradeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeSign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeTemplates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradeTemplateId",
                table: "Grades",
                column: "GradeTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_GradeTemplates_GradeTemplateId",
                table: "Grades",
                column: "GradeTemplateId",
                principalTable: "GradeTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_GradeTemplates_GradeTemplateId",
                table: "Grades");

            migrationBuilder.DropTable(
                name: "GradeTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Grades_GradeTemplateId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "WriteGrade",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "GradeTemplateId",
                table: "Grades",
                newName: "GradeValue");
        }
    }
}
