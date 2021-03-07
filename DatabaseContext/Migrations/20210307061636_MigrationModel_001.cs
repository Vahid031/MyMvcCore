using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class MigrationModel_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "General");

            migrationBuilder.CreateTable(
                name: "Branchs",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<int>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Branchs_Branchs_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "General",
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Controller = table.Column<string>(maxLength: 25, nullable: true),
                    Action = table.Column<string>(maxLength: 25, nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Icon = table.Column<string>(maxLength: 25, nullable: true),
                    Visible = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "General",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    NationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "General",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 25, nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Members_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "General",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchRoles",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    BranchId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchRoles", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BranchRoles_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "General",
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BranchRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "General",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    TableName = table.Column<string>(maxLength: 50, nullable: true),
                    RowId = table.Column<Guid>(nullable: true),
                    State = table.Column<byte>(maxLength: 10, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Logs_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "General",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberPermissions",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: true),
                    PermissionId = table.Column<Guid>(nullable: true),
                    IsDenied = table.Column<bool>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "LogDetails",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Key = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(maxLength: 50, nullable: true),
                    LogId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDetails", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_LogDetails_Logs_LogId",
                        column: x => x.LogId,
                        principalSchema: "General",
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchRoles_BranchId",
                schema: "General",
                table: "BranchRoles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRoles_CreateDate",
                schema: "General",
                table: "BranchRoles",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchRoles_RoleId",
                schema: "General",
                table: "BranchRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_CreateDate",
                schema: "General",
                table: "Branchs",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_ParentId",
                schema: "General",
                table: "Branchs",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LogDetails_CreateDate",
                schema: "General",
                table: "LogDetails",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_LogDetails_LogId",
                schema: "General",
                table: "LogDetails",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CreateDate",
                schema: "General",
                table: "Logs",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_MemberId",
                schema: "General",
                table: "Logs",
                column: "MemberId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Members_CreateDate",
                schema: "General",
                table: "Members",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonId",
                schema: "General",
                table: "Members",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreateDate",
                schema: "General",
                table: "Permissions",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                schema: "General",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreateDate",
                schema: "General",
                table: "Persons",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreateDate",
                schema: "General",
                table: "Roles",
                column: "CreateDate",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ParentId",
                schema: "General",
                table: "Roles",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchRoles",
                schema: "General");

            migrationBuilder.DropTable(
                name: "LogDetails",
                schema: "General");

            migrationBuilder.DropTable(
                name: "MemberPermissions",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Branchs",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Logs",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "General");
        }
    }
}
