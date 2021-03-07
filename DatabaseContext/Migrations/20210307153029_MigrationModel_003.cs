using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class MigrationModel_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "General",
                table: "Branchs",
                columns: new[] { "Id", "CreateDate", "ParentId", "Title", "Type" },
                values: new object[] { new Guid("41c33ac0-dae6-4a02-ba29-be74c6e9f98f"), new DateTime(2021, 3, 7, 19, 0, 29, 177, DateTimeKind.Local).AddTicks(1040), null, "Main", null });

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
                values: new object[] { new Guid("a98ee288-942e-4f39-bfe7-81765d4dbceb"), new DateTime(1993, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 7, 19, 0, 29, 172, DateTimeKind.Local).AddTicks(9611), "Vahid031@yahoo.com", "وحید", true, "گودرزی", "09212681463", "0310956196", "02634558363" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "ParentId", "Title" },
                values: new object[] { new Guid("81bd3e58-8d58-4757-adec-90610ad04fef"), new DateTime(2021, 3, 7, 19, 0, 29, 177, DateTimeKind.Local).AddTicks(322), null, "Admin" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "BranchRoles",
                columns: new[] { "Id", "BranchId", "CreateDate", "RoleId" },
                values: new object[] { new Guid("c01fe8f6-41c7-4440-86bb-50816ebc2838"), new Guid("41c33ac0-dae6-4a02-ba29-be74c6e9f98f"), new DateTime(2021, 3, 7, 19, 0, 29, 177, DateTimeKind.Local).AddTicks(1755), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Members",
                columns: new[] { "Id", "Active", "CreateDate", "Password", "PersonId", "UserName" },
                values: new object[] { new Guid("8a5e037d-9c1d-46eb-9002-fca33d446e37"), true, new DateTime(2021, 3, 7, 19, 0, 29, 176, DateTimeKind.Local).AddTicks(7913), "10921321718522810424013620812023319215824350233", new Guid("a98ee288-942e-4f39-bfe7-81765d4dbceb"), "admin" });

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
                    { new Guid("3314925a-2866-4dcf-b0ea-afd75a1e20a9"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(2203), new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("8369172c-97b2-4e2e-a144-a24830ac7d04"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3503), new Guid("e6ebe0b5-601a-4fcc-adba-0e30d861c2f4"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "BranchRoleMembers",
                columns: new[] { "Id", "BranchRoleId", "CreateDate", "MemberId" },
                values: new object[] { new Guid("248013bb-7a27-48ba-9e44-a406dda638b9"), new Guid("c01fe8f6-41c7-4440-86bb-50816ebc2838"), new DateTime(2021, 3, 7, 19, 0, 29, 178, DateTimeKind.Local).AddTicks(7721), new Guid("8a5e037d-9c1d-46eb-9002-fca33d446e37") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
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
                    { new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"), "_List", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(2625), "fa fa-list", 2, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "اطلاعات", false },
                    { new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"), "_Tree", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Unspecified).AddTicks(3547), "fa fa-list-ul", 6, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "نمایش درختی", false }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("5510f93f-c8ad-4740-968e-7ee9c059c11c"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3637), new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("7f33f3a9-d825-469d-857b-d6e37dc76f7a"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3602), new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("e292a827-6c8e-4cd6-9ad8-607f8c532a94"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3575), new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") }
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
                    { new Guid("9293c3eb-207e-4b78-8fed-6d3b96437302"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4020), new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("c505278a-0a2f-4eac-ae51-e7fc3e7b1b9b"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3902), new Guid("b41312d1-cec1-4f3b-935f-5359bba15936"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("e2f06773-2164-46e4-b286-b3ab87249477"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3879), new Guid("9e404679-1059-495e-aaec-9aa9371ed354"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("88e05075-8dd6-40c3-a883-93c1bfe4381d"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3856), new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("6dca39aa-434a-4312-9acb-387ac788e42d"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3833), new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("3351f8a6-fe9d-4b68-999a-6faa9e79fbcd"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3806), new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("a154b6ed-80ff-434a-9f71-44fb867293a6"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3783), new Guid("a05ecc96-0663-4fb2-aabd-18dede5a5cff"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("3903a518-c1ba-4a8e-a2fb-f59baa220d45"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3924), new Guid("b9a02ea5-dd3f-48a8-831b-5f4154544f00"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("6932d95a-bfba-4262-a35c-62be61026c83"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3760), new Guid("3a4b0912-7700-41cd-84ca-9986a6af982a"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("9aaeee6c-b9ef-425c-b3d2-2207226ed917"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3735), new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("b0fae8ec-efe3-4ffd-bd16-69c14af4efcf"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3712), new Guid("0c19f3a5-a90c-4760-968d-af6028fef21f"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("d9b3f429-74bd-40c8-90fd-a652ed4f2025"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3688), new Guid("67323792-38c3-490b-ba31-eb87c1087ea6"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("2b18e304-c1e2-4cf8-baf8-e90c4ed08a30"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3664), new Guid("e7c93552-4e07-4d69-ba6a-baa5229c2278"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("177bdb67-5947-4019-8912-f19d90204c0e"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4235), new Guid("4a6668fe-92ce-47e9-ac44-73312d71a602"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("4e9e87f2-033c-4b1c-bbf5-a5e1852727a5"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4211), new Guid("643eef28-7e01-40d8-bfe7-4cd5c95c770e"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("40a3634b-5a40-4004-9582-a1f577f1a768"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4187), new Guid("07760487-9097-4431-b7b9-b6dbf9bd9416"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("ce8d0ceb-d62b-437f-a805-ff02cc1e167c"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4164), new Guid("15c526e5-879a-4a4a-84fb-06941ec9e78e"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("4f13f41d-b67f-4bde-a183-f9ede4bb69b0"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4139), new Guid("d49cdafd-e0ae-46c1-ba80-d4a9b71f86a6"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("28f037fc-616d-4ac5-8804-091d62a2b5e1"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4259), new Guid("44683454-d0a3-48ee-bc83-fa18f6103e65"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") },
                    { new Guid("6fbebd58-1813-4f37-aba9-d58958f1628f"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(4282), new Guid("fc5a8eae-9287-4efc-91de-9d1c47e19aa6"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("162a9fe7-8fbd-4759-8025-cfc2f0eea7b7"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3972), new Guid("0b56bebc-01ff-4619-bd45-4652fecef76e"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("4c0e9270-5d1c-4e61-b2eb-d36e1dee9008"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3949), new Guid("cb313af5-85ba-42b0-a263-6ae1549dc13b"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("adddc242-d853-4d3e-938b-965aed02e3e7"), new DateTime(2021, 3, 7, 19, 0, 29, 279, DateTimeKind.Local).AddTicks(3995), new Guid("3c3f40b8-7399-41d5-a5ce-00c6e0ffb583"), new Guid("81bd3e58-8d58-4757-adec-90610ad04fef") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "General",
                table: "BranchRoleMembers",
                keyColumn: "Id",
                keyValue: new Guid("248013bb-7a27-48ba-9e44-a406dda638b9"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("162a9fe7-8fbd-4759-8025-cfc2f0eea7b7"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("177bdb67-5947-4019-8912-f19d90204c0e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("28f037fc-616d-4ac5-8804-091d62a2b5e1"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2b18e304-c1e2-4cf8-baf8-e90c4ed08a30"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3314925a-2866-4dcf-b0ea-afd75a1e20a9"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3351f8a6-fe9d-4b68-999a-6faa9e79fbcd"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3903a518-c1ba-4a8e-a2fb-f59baa220d45"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("40a3634b-5a40-4004-9582-a1f577f1a768"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4c0e9270-5d1c-4e61-b2eb-d36e1dee9008"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4e9e87f2-033c-4b1c-bbf5-a5e1852727a5"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4f13f41d-b67f-4bde-a183-f9ede4bb69b0"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5510f93f-c8ad-4740-968e-7ee9c059c11c"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6932d95a-bfba-4262-a35c-62be61026c83"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6dca39aa-434a-4312-9acb-387ac788e42d"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6fbebd58-1813-4f37-aba9-d58958f1628f"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7f33f3a9-d825-469d-857b-d6e37dc76f7a"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8369172c-97b2-4e2e-a144-a24830ac7d04"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("88e05075-8dd6-40c3-a883-93c1bfe4381d"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9293c3eb-207e-4b78-8fed-6d3b96437302"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9aaeee6c-b9ef-425c-b3d2-2207226ed917"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a154b6ed-80ff-434a-9f71-44fb867293a6"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("adddc242-d853-4d3e-938b-965aed02e3e7"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b0fae8ec-efe3-4ffd-bd16-69c14af4efcf"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c505278a-0a2f-4eac-ae51-e7fc3e7b1b9b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ce8d0ceb-d62b-437f-a805-ff02cc1e167c"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d9b3f429-74bd-40c8-90fd-a652ed4f2025"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e292a827-6c8e-4cd6-9ad8-607f8c532a94"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e2f06773-2164-46e4-b286-b3ab87249477"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "BranchRoles",
                keyColumn: "Id",
                keyValue: new Guid("c01fe8f6-41c7-4440-86bb-50816ebc2838"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("8a5e037d-9c1d-46eb-9002-fca33d446e37"));

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
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("41c33ac0-dae6-4a02-ba29-be74c6e9f98f"));

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
                keyValue: new Guid("a98ee288-942e-4f39-bfe7-81765d4dbceb"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("81bd3e58-8d58-4757-adec-90610ad04fef"));

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
