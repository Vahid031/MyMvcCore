using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class MigrationModel_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "", true, "", new DateTime(2021, 1, 29, 22, 58, 48, 660, DateTimeKind.Unspecified).AddTicks(7050), "fa fa-address-book", 1, null, "اطلاعات پایه", true },
                    { new Guid("e6ebe0b5-601a-4fcc-adba-0e30d861c2f4"), "", true, "", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(1038), "fa fa-server", 2, null, "سیستم", true }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Persons",
                columns: new[] { "Id", "Birthday", "CreateDate", "Email", "FirstName", "Gender", "LastName", "MobileNumber", "NationalCode", "PhoneNumber" },
                values: new object[] { new Guid("a2dd8769-8830-48ed-963c-d06a47baa1d4"), new DateTime(1993, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 4, 22, 56, 48, 786, DateTimeKind.Local).AddTicks(7487), "Vahid031@yahoo.com", "وحید", true, "گودرزی", "09212681463", "0310956196", "02634558363" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "ParentId", "Title" },
                values: new object[] { new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8"), new DateTime(2021, 2, 4, 22, 56, 48, 794, DateTimeKind.Local).AddTicks(7678), null, "Admin" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Members",
                columns: new[] { "Id", "Active", "CreateDate", "Password", "PersonId", "UserName" },
                values: new object[] { new Guid("c25129b9-07d6-42ca-91dd-756aefdced03"), true, new DateTime(2021, 2, 4, 22, 56, 48, 789, DateTimeKind.Local).AddTicks(9532), "10921321718522810424013620812023319215824350233", new Guid("a2dd8769-8830-48ed-963c-d06a47baa1d4"), "admin" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "Index", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(1250), "fa fa-users", 1, new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "تعریف نقش", true },
                    { new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "Index", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(1335), "fa fa-user", 2, new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "تعریف کاربر", true },
                    { new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "Index", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2258), "fa fa-cogs", 3, new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "سطح دسترسی", true }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("fdac15ae-5100-420b-aa77-a9b9002c233b"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(4722), new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("448d2c00-6b26-4fc6-8be3-c79235c69a77"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6107), new Guid("e6ebe0b5-601a-4fcc-adba-0e30d861c2f4"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"), "_Tree", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3547), "fa fa-list-ul", 6, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "نمایش درختی", false },
                    { new Guid("fc5a8eae-9287-4efc-91de-9d1c47e19aa6"), "_Tree", true, "Permission", new DateTime(2021, 2, 4, 22, 25, 6, 390, DateTimeKind.Unspecified), "fa fa-list-ul", 10, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "نمایش درختی", false },
                    { new Guid("b9a02ea5-dd3f-48a8-831b-5f4154544f00"), "_Delete", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3256), "fa fa-trash", 3, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "حذف", false },
                    { new Guid("b41312d1-cec1-4f3b-935f-5359bba15936"), "_List", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3177), "fa fa-list", 5, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "اطلاعات", false },
                    { new Guid("9e404679-1059-495e-aaec-9aa9371ed354"), "_Update", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3057), "fa fa-edit", 4, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "ویرایش", false },
                    { new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), "_Member", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2987), "fa fa-user", 7, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "کاربر", false },
                    { new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), "_Order", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2912), "fa fa-list-ol", 6, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "اولویت بندی", false },
                    { new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), "_Role", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2842), "fa fa-users", 8, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "گروه کاربری", false },
                    { new Guid("a05ecc96-0663-4fb2-aabd-18dede5a5cff"), "_Create", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2772), "fa fa-plus", 2, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "ثبت", false },
                    { new Guid("3a4b0912-7700-41cd-84ca-9986a6af982a"), "_Menu", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2700), "fa fa-navicon", 1, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "منو", false },
                    { new Guid("44683454-d0a3-48ee-bc83-fa18f6103e65"), "_Permission", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(4022), "fa fa-cogs", 5, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "دسترسی", false },
                    { new Guid("0c19f3a5-a90c-4760-968d-af6028fef21f"), "_Delete", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2547), "fa fa-trash", 1, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "حذف", false },
                    { new Guid("67323792-38c3-490b-ba31-eb87c1087ea6"), "_Update", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2464), "fa fa-edit", 3, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "ویرایش", false },
                    { new Guid("e7c93552-4e07-4d69-ba6a-baa5229c2278"), "_Create", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2389), "fa fa-plus", 4, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "ثبت", false },
                    { new Guid("4a6668fe-92ce-47e9-ac44-73312d71a602"), "_Permission", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3907), "fa fa-cogs", 7, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "دسترسی", false },
                    { new Guid("643eef28-7e01-40d8-bfe7-4cd5c95c770e"), "_Delete", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3836), "fa fa-trash", 3, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "حذف", false },
                    { new Guid("07760487-9097-4431-b7b9-b6dbf9bd9416"), "_List", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3764), "fa fa-list", 4, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "اطلاعات", false },
                    { new Guid("15c526e5-879a-4a4a-84fb-06941ec9e78e"), "_Update", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3692), "fa fa-edit", 2, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "ویرایش", false },
                    { new Guid("d49cdafd-e0ae-46c1-ba80-d4a9b71f86a6"), "_Create", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3620), "fa fa-plus", 1, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "ثبت", false },
                    { new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"), "_List", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2625), "fa fa-list", 2, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "اطلاعات", false }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RoleMembers",
                columns: new[] { "Id", "CreateDate", "MemberId", "RoleId" },
                values: new object[] { new Guid("680e3c93-26c8-41d1-84a5-19ac0dff9d40"), new DateTime(2021, 2, 4, 22, 56, 48, 796, DateTimeKind.Local).AddTicks(3804), new Guid("c25129b9-07d6-42ca-91dd-756aefdced03"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("fbaa0e07-bb13-4daa-a5f8-605119b7c273"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6219), new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("c2cecf02-043d-4bf7-a259-83115191460b"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6193), new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("edee7f40-5398-4e68-9885-c1f0c91dd63a"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6167), new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("3c3f40b8-7399-41d5-a5ce-00c6e0ffb583"), "SetMemberPermission", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3475), "fa fa-edit", 1, new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), "تخصیص دسترسی کاربر", false },
                    { new Guid("cb313af5-85ba-42b0-a263-6ae1549dc13b"), "ChangePeriority", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3332), "fa fa-edit", 1, new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), "تغییر اولویت", false },
                    { new Guid("0b56bebc-01ff-4619-bd45-4652fecef76e"), "SetRolePermission", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3404), "fa fa-edit", 1, new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), "تخصیص دسترسی گروه", false }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("8b04925f-d5dc-4b04-abcc-61c84c460b2e"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6647), new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("f6757ba4-56da-488f-9dfa-91bce4fddc73"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6485), new Guid("b41312d1-cec1-4f3b-935f-5359bba15936"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("27b4f154-d587-4940-89de-83b1cac8f7a8"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6462), new Guid("9e404679-1059-495e-aaec-9aa9371ed354"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("73eae3c9-e4c1-4294-96a5-ad22a4f1a5f5"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6439), new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("61d5a39e-bbfc-4ac3-b025-892e7d6115d8"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6416), new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("b4f5e44e-e62b-4f77-8c88-fdabd5aafb03"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6393), new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("569fc3c6-7d37-4d4b-b67d-07820608faa3"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6370), new Guid("a05ecc96-0663-4fb2-aabd-18dede5a5cff"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("8d1f1d16-98b8-48fc-86f9-235f54d96399"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6510), new Guid("b9a02ea5-dd3f-48a8-831b-5f4154544f00"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("d49f6d65-39b5-468c-bb9a-6b9fa8afe552"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6346), new Guid("3a4b0912-7700-41cd-84ca-9986a6af982a"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("944a877a-d3ca-4029-b941-f8b16c4cd6f8"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6321), new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("6fb93b72-cbde-4a17-becb-04499cfd196a"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6291), new Guid("0c19f3a5-a90c-4760-968d-af6028fef21f"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("83c4fee5-b74d-49f9-9521-474e938f8aac"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6267), new Guid("67323792-38c3-490b-ba31-eb87c1087ea6"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("f85e0c94-8f29-4ad9-a427-3a7c004e4cd6"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6245), new Guid("e7c93552-4e07-4d69-ba6a-baa5229c2278"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("42ab6030-fa62-47ec-a107-3d999be98778"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6766), new Guid("4a6668fe-92ce-47e9-ac44-73312d71a602"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("8bbc66a0-dbc3-40f7-a5b9-c73537ce1de5"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6742), new Guid("643eef28-7e01-40d8-bfe7-4cd5c95c770e"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("80e308c5-286c-4ace-ae67-8c999a1a0b64"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6717), new Guid("07760487-9097-4431-b7b9-b6dbf9bd9416"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("9497d078-c5c4-48f3-b389-e900aec5df56"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6694), new Guid("15c526e5-879a-4a4a-84fb-06941ec9e78e"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("d7ececdd-10b1-4a6d-ac47-c4d3073ae1bf"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6671), new Guid("d49cdafd-e0ae-46c1-ba80-d4a9b71f86a6"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("b85ef976-a3be-425f-9dda-b9a9b1fbfb1e"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6789), new Guid("44683454-d0a3-48ee-bc83-fa18f6103e65"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") },
                    { new Guid("fe37f838-dda3-49fb-abf6-c5dc186b8bf4"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6811), new Guid("fc5a8eae-9287-4efc-91de-9d1c47e19aa6"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("65b3bbd3-21f7-45af-9e08-26c0417a427c"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6597), new Guid("0b56bebc-01ff-4619-bd45-4652fecef76e"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("19ab5988-88db-43f3-84ff-2ca5a649b317"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6535), new Guid("cb313af5-85ba-42b0-a263-6ae1549dc13b"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("3dd8835e-9284-44a5-824f-6a9bac54d4bd"), new DateTime(2021, 2, 4, 22, 56, 48, 898, DateTimeKind.Local).AddTicks(6624), new Guid("3c3f40b8-7399-41d5-a5ce-00c6e0ffb583"), new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "General",
                table: "RoleMembers",
                keyColumn: "Id",
                keyValue: new Guid("680e3c93-26c8-41d1-84a5-19ac0dff9d40"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("19ab5988-88db-43f3-84ff-2ca5a649b317"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("27b4f154-d587-4940-89de-83b1cac8f7a8"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3dd8835e-9284-44a5-824f-6a9bac54d4bd"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("42ab6030-fa62-47ec-a107-3d999be98778"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("448d2c00-6b26-4fc6-8be3-c79235c69a77"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("569fc3c6-7d37-4d4b-b67d-07820608faa3"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("61d5a39e-bbfc-4ac3-b025-892e7d6115d8"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("65b3bbd3-21f7-45af-9e08-26c0417a427c"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6fb93b72-cbde-4a17-becb-04499cfd196a"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("73eae3c9-e4c1-4294-96a5-ad22a4f1a5f5"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("80e308c5-286c-4ace-ae67-8c999a1a0b64"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("83c4fee5-b74d-49f9-9521-474e938f8aac"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8b04925f-d5dc-4b04-abcc-61c84c460b2e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8bbc66a0-dbc3-40f7-a5b9-c73537ce1de5"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8d1f1d16-98b8-48fc-86f9-235f54d96399"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("944a877a-d3ca-4029-b941-f8b16c4cd6f8"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9497d078-c5c4-48f3-b389-e900aec5df56"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b4f5e44e-e62b-4f77-8c88-fdabd5aafb03"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b85ef976-a3be-425f-9dda-b9a9b1fbfb1e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c2cecf02-043d-4bf7-a259-83115191460b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d49f6d65-39b5-468c-bb9a-6b9fa8afe552"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d7ececdd-10b1-4a6d-ac47-c4d3073ae1bf"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("edee7f40-5398-4e68-9885-c1f0c91dd63a"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f6757ba4-56da-488f-9dfa-91bce4fddc73"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f85e0c94-8f29-4ad9-a427-3a7c004e4cd6"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fbaa0e07-bb13-4daa-a5f8-605119b7c273"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fdac15ae-5100-420b-aa77-a9b9002c233b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fe37f838-dda3-49fb-abf6-c5dc186b8bf4"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("c25129b9-07d6-42ca-91dd-756aefdced03"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("07760487-9097-4431-b7b9-b6dbf9bd9416"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0b56bebc-01ff-4619-bd45-4652fecef76e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0c19f3a5-a90c-4760-968d-af6028fef21f"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("15c526e5-879a-4a4a-84fb-06941ec9e78e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3a4b0912-7700-41cd-84ca-9986a6af982a"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3c3f40b8-7399-41d5-a5ce-00c6e0ffb583"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("44683454-d0a3-48ee-bc83-fa18f6103e65"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("4a6668fe-92ce-47e9-ac44-73312d71a602"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("643eef28-7e01-40d8-bfe7-4cd5c95c770e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("67323792-38c3-490b-ba31-eb87c1087ea6"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9e404679-1059-495e-aaec-9aa9371ed354"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a05ecc96-0663-4fb2-aabd-18dede5a5cff"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b41312d1-cec1-4f3b-935f-5359bba15936"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b9a02ea5-dd3f-48a8-831b-5f4154544f00"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cb313af5-85ba-42b0-a263-6ae1549dc13b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d49cdafd-e0ae-46c1-ba80-d4a9b71f86a6"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e6ebe0b5-601a-4fcc-adba-0e30d861c2f4"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e7c93552-4e07-4d69-ba6a-baa5229c2278"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("fc5a8eae-9287-4efc-91de-9d1c47e19aa6"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e232441-90f0-422b-92e2-e4d91700eaa8"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("a2dd8769-8830-48ed-963c-d06a47baa1d4"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"));
        }
    }
}
