using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class DB_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberPermissions",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(nullable: true),
                    PermissionId = table.Column<int>(nullable: true),
                    IsDenied = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberPermissions_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "General",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "General",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberPermissions_MemberId",
                schema: "General",
                table: "MemberPermissions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPermissions_PermissionId",
                schema: "General",
                table: "MemberPermissions",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberPermissions",
                schema: "General");
        }
    }
}
