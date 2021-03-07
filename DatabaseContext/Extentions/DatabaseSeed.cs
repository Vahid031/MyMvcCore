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
            var person = new Person
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                FirstName = "وحید",
                LastName = "گودرزی",
                Gender = true,
                Email = "Vahid031@yahoo.com",
                Birthday = new DateTime(1993, 8, 26),
                NationalCode = "0310956196",
                MobileNumber = "09212681463",
                PhoneNumber = "02634558363"
            };
            var member = new Member
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true,
                UserName = "admin",
                Password = "10921321718522810424013620812023319215824350233",
                PersonId = person.Id

            };
            var role = new Role
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Title = "Admin"
            };

            var branch = new Branch
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Title = "Main"
            };

            var branchRole = new BranchRole
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                BranchId = branch.Id,
                RoleId = role.Id
            };

            modelBuilder.Entity<Person>().HasData(person);
            modelBuilder.Entity<Member>().HasData(member);
            modelBuilder.Entity<Role>().HasData(role);
            modelBuilder.Entity<Branch>().HasData(branch);
            modelBuilder.Entity<BranchRole>().HasData(branchRole);
            modelBuilder.Entity<BranchRoleMember>().HasData(new BranchRoleMember
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                BranchRoleId = branchRole.Id,
                MemberId = member.Id
            });

            // basic permissions
            var permissions = JsonConvert.DeserializeObject<List<Permission>>("[{'Id':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6','CreateDate':'2021-01-29T22:58:48.6607050','Title':'اطلاعات پایه','Controller':'','Action':'','Order':1,'Active':true,'Icon':'fa fa-address-book','Visible':true},{'Id':'E6EBE0B5-601A-4FCC-ADBA-0E30D861C2F4','CreateDate':'2021-01-29T22:58:48.6611038','Title':'سیستم','Controller':'','Action':'','Order':2,'Active':true,'Icon':'fa fa-server','Visible':true},{'Id':'9555BC99-4C77-4307-AA6E-30F2074DEF17','CreateDate':'2021-01-29T22:58:48.6611250','Title':'تعریف نقش','Controller':'Role','Action':'Index','Order':1,'Active':true,'ParentId':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6','Icon':'fa fa-users','Visible':true},{'Id':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','CreateDate':'2021-01-29T22:58:48.6611335','Title':'تعریف کاربر','Controller':'Member','Action':'Index','Order':2,'Active':true,'ParentId':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6','Icon':'fa fa-user','Visible':true},{'Id':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','CreateDate':'2021-01-29T22:58:48.6612258','Title':'سطح دسترسی','Controller':'Permission','Action':'Index','Order':3,'Active':true,'ParentId':'2164228A-2DF8-4A6B-9A36-EEE99BCD2CB6','Icon':'fa fa-cogs','Visible':true},{'Id':'E7C93552-4E07-4D69-BA6A-BAA5229C2278','CreateDate':'2021-01-29T22:58:48.6612389','Title':'ثبت','Controller':'Member','Action':'_Create','Order':4,'Active':true,'ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','Icon':'fa fa-plus','Visible':false},{'Id':'67323792-38C3-490B-BA31-EB87C1087EA6','CreateDate':'2021-01-29T22:58:48.6612464','Title':'ویرایش','Controller':'Member','Action':'_Update','Order':3,'Active':true,'ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','Icon':'fa fa-edit','Visible':false},{'Id':'0C19F3A5-A90C-4760-968D-AF6028FEF21F','CreateDate':'2021-01-29T22:58:48.6612547','Title':'حذف','Controller':'Member','Action':'_Delete','Order':1,'Active':true,'ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','Icon':'fa fa-trash','Visible':false},{'Id':'547E86BE-132E-41F7-A8F3-73EB25BD755B','CreateDate':'2021-01-29T22:58:48.6612625','Title':'اطلاعات','Controller':'Member','Action':'_List','Order':2,'Active':true,'ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','Icon':'fa fa-list','Visible':false},{'Id':'3A4B0912-7700-41CD-84CA-9986A6AF982A','CreateDate':'2021-01-29T22:58:48.6612700','Title':'منو','Controller':'Permission','Action':'_Menu','Order':1,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-navicon','Visible':false},{'Id':'A05ECC96-0663-4FB2-AABD-18DEDE5A5CFF','CreateDate':'2021-01-29T22:58:48.6612772','Title':'ثبت','Controller':'Permission','Action':'_Create','Order':2,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-plus','Visible':false},{'Id':'FF298292-BE77-43A0-AC99-D31F6C38C0BB','CreateDate':'2021-01-29T22:58:48.6612842','Title':'گروه کاربری','Controller':'Permission','Action':'_Role','Order':8,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-users','Visible':false},{'Id':'0DA690BC-F675-4D8F-82F5-E6D4A5F82918','CreateDate':'2021-01-29T22:58:48.6612912','Title':'اولویت بندی','Controller':'Permission','Action':'_Order','Order':6,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-list-ol','Visible':false},{'Id':'8C4994A2-A808-4C81-8086-EE501B2AC0FE','CreateDate':'2021-01-29T22:58:48.6612987','Title':'کاربر','Controller':'Permission','Action':'_Member','Order':7,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-user','Visible':false},{'Id':'9E404679-1059-495E-AAEC-9AA9371ED354','CreateDate':'2021-01-29T22:58:48.6613057','Title':'ویرایش','Controller':'Permission','Action':'_Update','Order':4,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-edit','Visible':false},{'Id':'B41312D1-CEC1-4F3B-935F-5359BBA15936','CreateDate':'2021-01-29T22:58:48.6613177','Title':'اطلاعات','Controller':'Permission','Action':'_List','Order':5,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-list','Visible':false},{'Id':'B9A02EA5-DD3F-48A8-831B-5F4154544F00','CreateDate':'2021-01-29T22:58:48.6613256','Title':'حذف','Controller':'Permission','Action':'_Delete','Order':3,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-trash','Visible':false},{'Id':'CB313AF5-85BA-42B0-A263-6AE1549DC13B','CreateDate':'2021-01-29T22:58:48.6613332','Title':'تغییر اولویت','Controller':'Permission','Action':'ChangePeriority','Order':1,'Active':true,'ParentId':'0DA690BC-F675-4D8F-82F5-E6D4A5F82918','Icon':'fa fa-edit','Visible':false},{'Id':'0B56BEBC-01FF-4619-BD45-4652FECEF76E','CreateDate':'2021-01-29T22:58:48.6613404','Title':'تخصیص دسترسی گروه','Controller':'Permission','Action':'SetRolePermission','Order':1,'Active':true,'ParentId':'FF298292-BE77-43A0-AC99-D31F6C38C0BB','Icon':'fa fa-edit','Visible':false},{'Id':'3C3F40B8-7399-41D5-A5CE-00C6E0FFB583','CreateDate':'2021-01-29T22:58:48.6613475','Title':'تخصیص دسترسی کاربر','Controller':'Permission','Action':'SetMemberPermission','Order':1,'Active':true,'ParentId':'8C4994A2-A808-4C81-8086-EE501B2AC0FE','Icon':'fa fa-edit','Visible':false},{'Id':'9009F178-1385-4FED-B0A7-ABD5AEE7A521','CreateDate':'2021-01-29T22:58:48.6613547','Title':'نمایش درختی','Controller':'Role','Action':'_Tree','Order':6,'Active':true,'ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17','Icon':'fa fa-list-ul','Visible':false},{'Id':'D49CDAFD-E0AE-46C1-BA80-D4A9B71F86A6','CreateDate':'2021-01-29T22:58:48.6613620','Title':'ثبت','Controller':'Role','Action':'_Create','Order':1,'Active':true,'ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17','Icon':'fa fa-plus','Visible':false},{'Id':'15C526E5-879A-4A4A-84FB-06941EC9E78E','CreateDate':'2021-01-29T22:58:48.6613692','Title':'ویرایش','Controller':'Role','Action':'_Update','Order':2,'Active':true,'ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17','Icon':'fa fa-edit','Visible':false},{'Id':'07760487-9097-4431-B7B9-B6DBF9BD9416','CreateDate':'2021-01-29T22:58:48.6613764','Title':'اطلاعات','Controller':'Role','Action':'_List','Order':4,'Active':true,'ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17','Icon':'fa fa-list','Visible':false},{'Id':'643EEF28-7E01-40D8-BFE7-4CD5C95C770E','CreateDate':'2021-01-29T22:58:48.6613836','Title':'حذف','Controller':'Role','Action':'_Delete','Order':3,'Active':true,'ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17','Icon':'fa fa-trash','Visible':false},{'Id':'4A6668FE-92CE-47E9-AC44-73312D71A602','CreateDate':'2021-01-29T22:58:48.6613907','Title':'دسترسی','Controller':'Role','Action':'_Permission','Order':7,'Active':true,'ParentId':'9555BC99-4C77-4307-AA6E-30F2074DEF17','Icon':'fa fa-cogs','Visible':false},{'Id':'44683454-D0A3-48EE-BC83-FA18F6103E65','CreateDate':'2021-01-29T22:58:48.6614022','Title':'دسترسی','Controller':'Member','Action':'_Permission','Order':5,'Active':true,'ParentId':'5F11ABF0-8E5C-4B95-BC56-DB6D5581C423','Icon':'fa fa-cogs','Visible':false},{'Id':'FC5A8EAE-9287-4EFC-91DE-9D1C47E19AA6','CreateDate':'2021-02-04T22:25:06.3900000','Title':'نمایش درختی','Controller':'Permission','Action':'_Tree','Order':10,'Active':true,'ParentId':'8AA921C5-0E6F-4E35-B80A-5D76065AC615','Icon':'fa fa-list-ul','Visible':false}]");

            modelBuilder.Entity<Permission>().HasData(permissions);

            permissions.ForEach(permission =>
             modelBuilder.Entity<RolePermission>().HasData(new RolePermission()
             {
                 Id = Guid.NewGuid(),
                 CreateDate = DateTime.Now,
                 PermissionId = permission.Id,
                 RoleId = role.Id
             })
            );
        }

    }
}