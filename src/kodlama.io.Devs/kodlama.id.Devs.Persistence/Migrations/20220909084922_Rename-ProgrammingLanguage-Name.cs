using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kodlama.io.Devs.Persistence.Migrations
{
    public partial class RenameProgrammingLanguageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_ProgrammingLanguage_ProgrammingLanguageId",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammingLanguage",
                table: "ProgrammingLanguage");

            migrationBuilder.RenameTable(
                name: "ProgrammingLanguage",
                newName: "ProgrammingLanguages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammingLanguages",
                table: "ProgrammingLanguages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technologies",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammingLanguages",
                table: "ProgrammingLanguages");

            migrationBuilder.RenameTable(
                name: "ProgrammingLanguages",
                newName: "ProgrammingLanguage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammingLanguage",
                table: "ProgrammingLanguage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_ProgrammingLanguage_ProgrammingLanguageId",
                table: "Technologies",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
