using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class DB_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                schema: "General",
                table: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                schema: "General",
                table: "Permissions",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                schema: "General",
                table: "Permissions",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                schema: "General",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Controller",
                schema: "General",
                table: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "General",
                table: "Permissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
