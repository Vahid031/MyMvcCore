using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class DB_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "General",
                table: "Permissions",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                schema: "General",
                table: "Permissions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "General",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Visible",
                schema: "General",
                table: "Permissions");
        }
    }
}
