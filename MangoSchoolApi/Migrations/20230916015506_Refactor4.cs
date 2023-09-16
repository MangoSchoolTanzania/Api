using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class Refactor4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arith",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Ave",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "HE",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Kus",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Pos",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "SA",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Writ",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Class",
                newName: "Name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Class",
                type: "bit",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Class",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<short>(type: "smallint", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Arith = table.Column<int>(type: "int", nullable: false),
                    Kus = table.Column<int>(type: "int", nullable: false),
                    HE = table.Column<int>(type: "int", nullable: false),
                    SA = table.Column<int>(type: "int", nullable: false),
                    Writ = table.Column<int>(type: "int", nullable: false),
                    Read = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Ave = table.Column<int>(type: "int", nullable: false),
                    Pos = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_ClassId",
                table: "Result",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Class",
                newName: "UserName");

            migrationBuilder.AlterColumn<short>(
                name: "IsActive",
                table: "Class",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Class",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Arith",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ave",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HE",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kus",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pos",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Read",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SA",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Writ",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
