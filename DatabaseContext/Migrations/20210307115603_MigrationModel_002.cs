using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class MigrationModel_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberPermissions",
                schema: "General");

            migrationBuilder.CreateTable(
                name: "BranchRoleMembers",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: true),
                    BranchRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchRoleMembers", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BranchRoleMembers_BranchRoles_BranchRoleId",
                        column: x => x.BranchRoleId,
                        principalSchema: "General",
                        principalTable: "BranchRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BranchRoleMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "General",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    PermissionId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "General",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "General",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchRoleMembers_BranchRoleId",
                schema: "General",
                table: "BranchRoleMembers",
                column: "BranchRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRoleMembers_CreateDate",
                schema: "General",
                table: "BranchRoleMembers",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchRoleMembers_MemberId",
                schema: "General",
                table: "BranchRoleMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CreateDate",
                schema: "General",
                table: "RolePermissions",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                schema: "General",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                schema: "General",
                table: "RolePermissions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchRoleMembers",
                schema: "General");

            migrationBuilder.DropTable(
                name: "RolePermissions",
                schema: "General");

            migrationBuilder.CreateTable(
                name: "MemberPermissions",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDenied = table.Column<bool>(type: "bit", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPermissions", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
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
                name: "IX_MemberPermissions_CreateDate",
                schema: "General",
                table: "MemberPermissions",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

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
    }
}
