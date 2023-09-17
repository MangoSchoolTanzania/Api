using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class refactorResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Result",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Class",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<short>(
                name: "IsActive",
                table: "Class",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Result",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Class",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Class",
                type: "bit",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
