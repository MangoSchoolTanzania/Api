using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class Refactor3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Class",
                newName: "Month");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Month",
                table: "Class",
                newName: "Semester");
        }
    }
}
