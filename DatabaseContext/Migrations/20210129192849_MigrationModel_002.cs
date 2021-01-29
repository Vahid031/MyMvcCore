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
                values: new object[] { new Guid("7280161e-bdfe-48d9-90fa-d3b8c80df47e"), "Index", true, "Home", new DateTime(2021, 1, 29, 22, 58, 48, 635, DateTimeKind.Local).AddTicks(8200), "fa fa-home", 1, null, "صفحه اصلی سایت", true });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Persons",
                columns: new[] { "Id", "Birthday", "CreateDate", "Email", "FirstName", "Gender", "LastName", "MobileNumber", "NationalCode", "PhoneNumber" },
                values: new object[] { new Guid("3a7ecfe2-a437-4634-bb2d-d4e01f0d6ee8"), new DateTime(1993, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 22, 58, 48, 511, DateTimeKind.Local).AddTicks(1222), "Vahid031@yahoo.com", "وحید", true, "گودرزی", "09212681463", "0310956196", "02634558363" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "ParentId", "Title" },
                values: new object[] { new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9"), new DateTime(2021, 1, 29, 22, 58, 48, 519, DateTimeKind.Local).AddTicks(3305), null, "Admin" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Members",
                columns: new[] { "Id", "Active", "CreateDate", "Password", "PersonId", "UserName" },
                values: new object[] { new Guid("4c1b92e9-d68b-4794-8f0f-293b67eed97f"), true, new DateTime(2021, 1, 29, 22, 58, 48, 514, DateTimeKind.Local).AddTicks(2597), "10921321718522810424013620812023319215824350233", new Guid("3a7ecfe2-a437-4634-bb2d-d4e01f0d6ee8"), "admin" });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "", true, "", new DateTime(2021, 1, 29, 22, 58, 48, 660, DateTimeKind.Local).AddTicks(7050), "fa fa-address-book", 1, new Guid("7280161e-bdfe-48d9-90fa-d3b8c80df47e"), "اطلاعات پایه", true },
                    { new Guid("e6ebe0b5-601a-4fcc-adba-0e30d861c2f4"), "", true, "", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(1038), "fa fa-server", 2, new Guid("7280161e-bdfe-48d9-90fa-d3b8c80df47e"), "سیستم", true }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("4cce2b32-e16e-4ed0-97a9-d24cce60ef4b"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(6546), new Guid("7280161e-bdfe-48d9-90fa-d3b8c80df47e"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "Index", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(1250), "fa fa-users", 1, new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "تعریف نقش", true },
                    { new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "Index", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(1335), "fa fa-user", 2, new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "تعریف کاربر", true },
                    { new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "Index", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2258), "fa fa-cogs", 3, new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), "سطح دسترسی", true }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RoleMembers",
                columns: new[] { "Id", "CreateDate", "MemberId", "RoleId" },
                values: new object[] { new Guid("ad7ff4cc-802d-443f-a35a-c9b086b4fe39"), new DateTime(2021, 1, 29, 22, 58, 48, 520, DateTimeKind.Local).AddTicks(9498), new Guid("4c1b92e9-d68b-4794-8f0f-293b67eed97f"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("53d599d6-66b7-4754-a5e4-2c024a633172"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(7899), new Guid("2164228a-2df8-4a6b-9a36-eee99bcd2cb6"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("f50f3d99-f576-49ec-8d1a-00a113d147a0"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(7959), new Guid("e6ebe0b5-601a-4fcc-adba-0e30d861c2f4"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"), "_Tree", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3547), "fa fa-list-ul", 6, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "نمایش درختی", false },
                    { new Guid("b41312d1-cec1-4f3b-935f-5359bba15936"), "_List", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3177), "fa fa-list", 5, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "اطلاعات", false },
                    { new Guid("9e404679-1059-495e-aaec-9aa9371ed354"), "_Update", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3057), "fa fa-edit", 4, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "ویرایش", false },
                    { new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), "_Member", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2987), "fa fa-user", 7, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "کاربر", false },
                    { new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), "_Order", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2912), "fa fa-list-ol", 6, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "اولویت بندی", false },
                    { new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), "_Role", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2842), "fa fa-users", 8, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "گروه کاربری", false },
                    { new Guid("a05ecc96-0663-4fb2-aabd-18dede5a5cff"), "_Create", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2772), "fa fa-plus", 2, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "ثبت", false },
                    { new Guid("3a4b0912-7700-41cd-84ca-9986a6af982a"), "_Menu", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2700), "fa fa-navicon", 1, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "منو", false },
                    { new Guid("44683454-d0a3-48ee-bc83-fa18f6103e65"), "_Permission", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(4022), "fa fa-cogs", 5, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "دسترسی", false },
                    { new Guid("b9a02ea5-dd3f-48a8-831b-5f4154544f00"), "_Delete", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3256), "fa fa-trash", 3, new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), "حذف", false },
                    { new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"), "_List", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2625), "fa fa-list", 2, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "اطلاعات", false },
                    { new Guid("67323792-38c3-490b-ba31-eb87c1087ea6"), "_Update", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2464), "fa fa-edit", 3, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "ویرایش", false },
                    { new Guid("e7c93552-4e07-4d69-ba6a-baa5229c2278"), "_Create", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2389), "fa fa-plus", 4, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "ثبت", false },
                    { new Guid("4a6668fe-92ce-47e9-ac44-73312d71a602"), "_Permission", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3907), "fa fa-cogs", 7, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "دسترسی", false },
                    { new Guid("643eef28-7e01-40d8-bfe7-4cd5c95c770e"), "_Delete", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3836), "fa fa-trash", 3, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "حذف", false },
                    { new Guid("07760487-9097-4431-b7b9-b6dbf9bd9416"), "_List", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3764), "fa fa-list", 4, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "اطلاعات", false },
                    { new Guid("15c526e5-879a-4a4a-84fb-06941ec9e78e"), "_Update", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3692), "fa fa-edit", 2, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "ویرایش", false },
                    { new Guid("d49cdafd-e0ae-46c1-ba80-d4a9b71f86a6"), "_Create", true, "Role", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3620), "fa fa-plus", 1, new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), "ثبت", false },
                    { new Guid("0c19f3a5-a90c-4760-968d-af6028fef21f"), "_Delete", true, "Member", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(2547), "fa fa-trash", 1, new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), "حذف", false }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("5919fa34-41f9-4b32-8efd-f7e97988c6c1"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8018), new Guid("5f11abf0-8e5c-4b95-bc56-db6d5581c423"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("135251e8-2763-4f10-87d7-c73d990a3928"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(7986), new Guid("9555bc99-4c77-4307-aa6e-30f2074def17"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("d7c9d671-c888-4d25-9886-f9c3b91dacd7"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8046), new Guid("8aa921c5-0e6f-4e35-b80a-5d76065ac615"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "Permissions",
                columns: new[] { "Id", "Action", "Active", "Controller", "CreateDate", "Icon", "Order", "ParentId", "Title", "Visible" },
                values: new object[,]
                {
                    { new Guid("3c3f40b8-7399-41d5-a5ce-00c6e0ffb583"), "SetMemberPermission", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3475), "fa fa-edit", 1, new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), "تخصیص دسترسی کاربر", false },
                    { new Guid("cb313af5-85ba-42b0-a263-6ae1549dc13b"), "ChangePeriority", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3332), "fa fa-edit", 1, new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), "تغییر اولویت", false },
                    { new Guid("0b56bebc-01ff-4619-bd45-4652fecef76e"), "SetRolePermission", true, "Permission", new DateTime(2021, 1, 29, 22, 58, 48, 661, DateTimeKind.Local).AddTicks(3404), "fa fa-edit", 1, new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), "تخصیص دسترسی گروه", false }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("6f1b49df-e2d8-42b1-9526-fea2587cd71e"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8497), new Guid("9009f178-1385-4fed-b0a7-abd5aee7a521"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("1f214385-7cbd-41d0-9b00-ed3ffd83ea8d"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8347), new Guid("9e404679-1059-495e-aaec-9aa9371ed354"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("fc020d52-8bc0-4571-ad54-a9e13a1f4b94"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8269), new Guid("8c4994a2-a808-4c81-8086-ee501b2ac0fe"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("0aaab24c-cb5c-46a6-b31e-f69488de725c"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8245), new Guid("0da690bc-f675-4d8f-82f5-e6d4a5f82918"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("5ffcadbb-ad88-4d39-b135-6becb00f8307"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8221), new Guid("ff298292-be77-43a0-ac99-d31f6c38c0bb"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("7b49b467-6eaf-4549-a050-9b0e0e8e2828"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8195), new Guid("a05ecc96-0663-4fb2-aabd-18dede5a5cff"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("9600fc1d-6814-4627-afc3-b833dc798f79"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8170), new Guid("3a4b0912-7700-41cd-84ca-9986a6af982a"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("d1c36084-3998-4777-94ec-879bd9252597"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8640), new Guid("44683454-d0a3-48ee-bc83-fa18f6103e65"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("f4b79fc6-86df-4095-b39c-edf23a410f98"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8145), new Guid("547e86be-132e-41f7-a8f3-73eb25bd755b"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("4feb3228-0974-48d5-b51c-327d3a374913"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8120), new Guid("0c19f3a5-a90c-4760-968d-af6028fef21f"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("6d8eed21-8da6-4de0-813a-6d72afd12981"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8096), new Guid("67323792-38c3-490b-ba31-eb87c1087ea6"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("610e8678-2904-48ba-a071-a1f6c08fc49b"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8071), new Guid("e7c93552-4e07-4d69-ba6a-baa5229c2278"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("f3900c04-d65a-4301-8b17-48e7d4679ac2"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8616), new Guid("4a6668fe-92ce-47e9-ac44-73312d71a602"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("882a9c4b-2756-4760-be4f-609802e76c93"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8592), new Guid("643eef28-7e01-40d8-bfe7-4cd5c95c770e"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("34234e9c-998b-4739-99ee-e46770d14915"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8568), new Guid("07760487-9097-4431-b7b9-b6dbf9bd9416"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("ceda1863-5096-406b-a69f-9d677632d730"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8545), new Guid("15c526e5-879a-4a4a-84fb-06941ec9e78e"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("4f9afa33-dbcb-4f7a-825a-de0b14336f77"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8521), new Guid("d49cdafd-e0ae-46c1-ba80-d4a9b71f86a6"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("c0bb2eec-90f5-41ac-9a51-37f6f87bbfbf"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8373), new Guid("b41312d1-cec1-4f3b-935f-5359bba15936"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") },
                    { new Guid("1a84dc3f-eb28-4aa2-a581-e33d33a531f8"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8399), new Guid("b9a02ea5-dd3f-48a8-831b-5f4154544f00"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") }
                });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("619c0a06-7a9f-49b3-8083-10b31c3f90f7"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8448), new Guid("0b56bebc-01ff-4619-bd45-4652fecef76e"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("f0379d8a-7be6-4922-a884-ebf02b935eee"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8424), new Guid("cb313af5-85ba-42b0-a263-6ae1549dc13b"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") });

            migrationBuilder.InsertData(
                schema: "General",
                table: "RolePermissions",
                columns: new[] { "Id", "CreateDate", "PermissionId", "RoleId" },
                values: new object[] { new Guid("4f35dac0-0ed0-4f56-b78a-cdc6085a2061"), new DateTime(2021, 1, 29, 22, 58, 48, 662, DateTimeKind.Local).AddTicks(8474), new Guid("3c3f40b8-7399-41d5-a5ce-00c6e0ffb583"), new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "General",
                table: "RoleMembers",
                keyColumn: "Id",
                keyValue: new Guid("ad7ff4cc-802d-443f-a35a-c9b086b4fe39"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0aaab24c-cb5c-46a6-b31e-f69488de725c"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("135251e8-2763-4f10-87d7-c73d990a3928"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1a84dc3f-eb28-4aa2-a581-e33d33a531f8"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1f214385-7cbd-41d0-9b00-ed3ffd83ea8d"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("34234e9c-998b-4739-99ee-e46770d14915"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4cce2b32-e16e-4ed0-97a9-d24cce60ef4b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4f35dac0-0ed0-4f56-b78a-cdc6085a2061"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4f9afa33-dbcb-4f7a-825a-de0b14336f77"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4feb3228-0974-48d5-b51c-327d3a374913"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53d599d6-66b7-4754-a5e4-2c024a633172"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5919fa34-41f9-4b32-8efd-f7e97988c6c1"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5ffcadbb-ad88-4d39-b135-6becb00f8307"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("610e8678-2904-48ba-a071-a1f6c08fc49b"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("619c0a06-7a9f-49b3-8083-10b31c3f90f7"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6d8eed21-8da6-4de0-813a-6d72afd12981"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6f1b49df-e2d8-42b1-9526-fea2587cd71e"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7b49b467-6eaf-4549-a050-9b0e0e8e2828"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("882a9c4b-2756-4760-be4f-609802e76c93"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9600fc1d-6814-4627-afc3-b833dc798f79"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c0bb2eec-90f5-41ac-9a51-37f6f87bbfbf"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ceda1863-5096-406b-a69f-9d677632d730"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d1c36084-3998-4777-94ec-879bd9252597"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d7c9d671-c888-4d25-9886-f9c3b91dacd7"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f0379d8a-7be6-4922-a884-ebf02b935eee"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f3900c04-d65a-4301-8b17-48e7d4679ac2"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f4b79fc6-86df-4095-b39c-edf23a410f98"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f50f3d99-f576-49ec-8d1a-00a113d147a0"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fc020d52-8bc0-4571-ad54-a9e13a1f4b94"));

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("4c1b92e9-d68b-4794-8f0f-293b67eed97f"));

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6f2d54ec-f19e-487b-adbd-d4adf7e13be9"));

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
                keyValue: new Guid("3a7ecfe2-a437-4634-bb2d-d4e01f0d6ee8"));

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

            migrationBuilder.DeleteData(
                schema: "General",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7280161e-bdfe-48d9-90fa-d3b8c80df47e"));
        }
    }
}
