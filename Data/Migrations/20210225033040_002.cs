using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Projects",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "ImageFileData",
                table: "Projects",
                newName: "FileData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Projects",
                newName: "ImageFileName");

            migrationBuilder.RenameColumn(
                name: "FileData",
                table: "Projects",
                newName: "ImageFileData");
        }
    }
}
