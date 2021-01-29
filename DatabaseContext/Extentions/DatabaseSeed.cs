using System;
using Microsoft.EntityFrameworkCore;
using DomainModels.General;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseContext.Extentions
{
    public static class DatabaseSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // system admin
            var person = new Person()
            {
                FirstName = "وحید",
                LastName = "گودرزی",
                Gender = true,
                Email = "Vahid031@yahoo.com",
                Birthday = new DateTime(1993, 8, 26),
                NationalCode = "0310956196",
                MobileNumber = "09212681463",
                PhoneNumber = "02634558363"
            };
            var member = new Member()
            {
                Active = true,
                UserName = "admin",
                Password = Infrastructure.Common.Hashing.MultiEncrypt("a"),
                PersonId = person.Id

            };
            var role = new Role()
            {
                Title = "Admin"
            };

            modelBuilder.Entity<Person>().HasData(person);
            modelBuilder.Entity<Member>().HasData(member);
            modelBuilder.Entity<Role>().HasData(role);
            modelBuilder.Entity<RoleMember>().HasData(new RoleMember()
            {
                RoleId = role.Id,
                MemberId = member.Id
            });

            // basic permissions
            var permissions = JsonConvert.DeserializeObject<List<Permission>>("[{'Title':'صفحه اصلی سایت','Order':1,'Active':true,'Action':'Index','Controller':'Home','Icon':'fa fa-home','Visible':true,'Id':'7280161E-BDFE-48D9-90FA-D3B8C80DF47E'},{'Title':'اطلاعات پایه','Order':1,'Active':true,'Action':'','Controller':'','Icon':'fa fa-address-book','Visible':true,'Id':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6','ParentId':'7280161E-BDFE-48D9-90FA-D3B8C80DF47E'},{'Title':'سیستم','Order':2,'Active':true,'Action':'','Controller':'','Icon':'fa fa-server','Visible':true,'Id':'E6EBE0B5-601A-4FCC-ADBA-0E30D861C2F4','ParentId':'7280161E-BDFE-48D9-90FA-D3B8C80DF47E'},{'Title':'تعریف نقش','Order':1,'Active':true,'Action':'Index','Controller':'Role','Icon':'fa fa-users','Visible':true,'Id':'9555BC99-4C77-4307-AA6E-30F2074DEF17','ParentId':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6'},{'Title':'تعریف کاربر','Order':2,'Active':true,'Action':'Index','Controller':'Member','Icon':'fa fa-user','Visible':true,'Id':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','ParentId':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6'},{'Title':'سطح دسترسی','Order':3,'Active':true,'Action':'Index','Controller':'Permission','Icon':'fa fa-cogs','Visible':true,'Id':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','ParentId':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6'},{'Title':'ثبت','Order':4,'Active':true,'Action':'_Create','Controller':'Member','Icon':'fa fa-plus','Visible':false,'Id':'E7C93552-4E07-4D69-BA6A-BAA5229C2278','ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423'},{'Title':'ویرایش','Order':3,'Active':true,'Action':'_Update','Controller':'Member','Icon':'fa fa-edit','Visible':false,'Id':'67323792-38C3-490B-BA31-EB87C1087EA6','ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423'},{'Title':'حذف','Order':1,'Active':true,'Action':'_Delete','Controller':'Member','Icon':'fa fa-trash','Visible':false,'Id':'0C19F3A5-A90C-4760-968D-AF6028FEF21F','ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423'},{'Title':'اطلاعات','Order':2,'Active':true,'Action':'_List','Controller':'Member','Icon':'fa fa-list','Visible':false,'Id':'547E86BE-132E-41F7-A8F3-73EB25BD755B','ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423'},{'Title':'منو','Order':1,'Active':true,'Action':'_Menu','Controller':'Permission','Icon':'fa fa-navicon','Visible':false,'Id':'3A4B0912-7700-41CD-84CA-9986A6AF982A','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'ثبت','Order':2,'Active':true,'Action':'_Create','Controller':'Permission','Icon':'fa fa-plus','Visible':false,'Id':'A05ECC96-0663-4FB2-AABD-18DEDE5A5CFF','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'گروه کاربری','Order':8,'Active':true,'Action':'_Role','Controller':'Permission','Icon':'fa fa-users','Visible':false,'Id':'FF298292-BE77-43A0-AC99-D31F6C38C0BB','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'اولویت بندی','Order':6,'Active':true,'Action':'_Order','Controller':'Permission','Icon':'fa fa-list-ol','Visible':false,'Id':'0DA690BC-F675-4D8F-82F5-E6D4A5F82918','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'کاربر','Order':7,'Active':true,'Action':'_Member','Controller':'Permission','Icon':'fa fa-user','Visible':false,'Id':'8C4994A2-A808-4C81-8086-EE501B2AC0FE','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'ویرایش','Order':4,'Active':true,'Action':'_Update','Controller':'Permission','Icon':'fa fa-edit','Visible':false,'Id':'9E404679-1059-495E-AAEC-9AA9371ED354','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'اطلاعات','Order':5,'Active':true,'Action':'_List','Controller':'Permission','Icon':'fa fa-list','Visible':false,'Id':'B41312D1-CEC1-4F3B-935F-5359BBA15936','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'حذف','Order':3,'Active':true,'Action':'_Delete','Controller':'Permission','Icon':'fa fa-trash','Visible':false,'Id':'B9A02EA5-DD3F-48A8-831B-5F4154544F00','ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615'},{'Title':'تغییر اولویت','Order':1,'Active':true,'Action':'ChangePeriority','Controller':'Permission','Icon':'fa fa-edit','Visible':false,'Id':'CB313AF5-85BA-42B0-A263-6AE1549DC13B','ParentId':'0DA690BC-F675-4D8F-82F5-E6D4A5F82918'},{'Title':'تخصیص دسترسی گروه','Order':1,'Active':true,'Action':'SetRolePermission','Controller':'Permission','Icon':'fa fa-edit','Visible':false,'Id':'0B56BEBC-01FF-4619-BD45-4652FECEF76E','ParentId':'FF298292-BE77-43A0-AC99-D31F6C38C0BB'},{'Title':'تخصیص دسترسی کاربر','Order':1,'Active':true,'Action':'SetMemberPermission','Controller':'Permission','Icon':'fa fa-edit','Visible':false,'Id':'3C3F40B8-7399-41D5-A5CE-00C6E0FFB583','ParentId':'8C4994A2-A808-4C81-8086-EE501B2AC0FE'},{'Title':'نمایش درختی','Order':6,'Active':true,'Action':'_Tree','Controller':'Role','Icon':'fa fa-list-ul','Visible':false,'Id':'9009F178-1385-4FED-B0A7-ABD5AEE7A521','ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17'},{'Title':'ثبت','Order':1,'Active':true,'Action':'_Create','Controller':'Role','Icon':'fa fa-plus','Visible':false,'Id':'D49CDAFD-E0AE-46C1-BA80-D4A9B71F86A6','ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17'},{'Title':'ویرایش','Order':2,'Active':true,'Action':'_Update','Controller':'Role','Icon':'fa fa-edit','Visible':false,'Id':'15C526E5-879A-4A4A-84FB-06941EC9E78E','ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17'},{'Title':'اطلاعات','Order':4,'Active':true,'Action':'_List','Controller':'Role','Icon':'fa fa-list','Visible':false,'Id':'07760487-9097-4431-B7B9-B6DBF9BD9416','ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17'},{'Title':'حذف','Order':3,'Active':true,'Action':'_Delete','Controller':'Role','Icon':'fa fa-trash','Visible':false,'Id':'643EEF28-7E01-40D8-BFE7-4CD5C95C770E','ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17'},{'Title':'دسترسی','Order':7,'Active':true,'Action':'_Permission','Controller':'Role','Icon':'fa fa-cogs','Visible':false,'Id':'4A6668FE-92CE-47E9-AC44-73312D71A602','ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17'},{'Title':'دسترسی','Order':5,'Active':true,'Action':'_Permission','Controller':'Member','Icon':'fa fa-cogs','Visible':false,'Id':'44683454-D0A3-48EE-BC83-FA18F6103E65','ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423'}]");

            modelBuilder.Entity<Permission>().HasData(permissions);

            permissions.ForEach(permission =>
             modelBuilder.Entity<RolePermission>().HasData(new RolePermission()
             {
                 PermissionId = permission.Id,
                 RoleId = role.Id
             })
            );
        }

    }
}