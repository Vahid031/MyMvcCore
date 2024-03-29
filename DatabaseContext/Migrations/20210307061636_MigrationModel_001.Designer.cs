﻿// <auto-generated />
using System;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseContext.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210307061636_MigrationModel_001")]
    partial class MigrationModel_001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModels.General.Branch", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ParentId");

                    b.ToTable("Branchs","General");
                });

            modelBuilder.Entity("DomainModels.General.BranchRole", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("BranchId");

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("RoleId");

                    b.ToTable("BranchRoles","General");
                });

            modelBuilder.Entity("DomainModels.General.Log", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("State")
                        .HasColumnType("tinyint")
                        .HasMaxLength(10);

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("MemberId");

                    b.ToTable("Logs","General");
                });

            modelBuilder.Entity("DomainModels.General.LogDetail", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("LogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("LogId");

                    b.ToTable("LogDetails","General");
                });

            modelBuilder.Entity("DomainModels.General.Member", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("PersonId");

                    b.ToTable("Members","General");
                });

            modelBuilder.Entity("DomainModels.General.MemberPermission", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDenied")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("MemberId");

                    b.HasIndex("PermissionId");

                    b.ToTable("MemberPermissions","General");
                });

            modelBuilder.Entity("DomainModels.General.Permission", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Controller")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions","General");
                });

            modelBuilder.Entity("DomainModels.General.Person", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Persons","General");
                });

            modelBuilder.Entity("DomainModels.General.Role", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreateDate")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ParentId");

                    b.ToTable("Roles","General");
                });

            modelBuilder.Entity("DomainModels.General.Branch", b =>
                {
                    b.HasOne("DomainModels.General.Branch", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DomainModels.General.BranchRole", b =>
                {
                    b.HasOne("DomainModels.General.Branch", "Branch")
                        .WithMany("BranchRoles")
                        .HasForeignKey("BranchId");

                    b.HasOne("DomainModels.General.Role", "Role")
                        .WithMany("BranchRoles")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("DomainModels.General.Log", b =>
                {
                    b.HasOne("DomainModels.General.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("DomainModels.General.LogDetail", b =>
                {
                    b.HasOne("DomainModels.General.Log", "Log")
                        .WithMany("LogDetails")
                        .HasForeignKey("LogId");
                });

            modelBuilder.Entity("DomainModels.General.Member", b =>
                {
                    b.HasOne("DomainModels.General.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("DomainModels.General.MemberPermission", b =>
                {
                    b.HasOne("DomainModels.General.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("DomainModels.General.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId");
                });

            modelBuilder.Entity("DomainModels.General.Permission", b =>
                {
                    b.HasOne("DomainModels.General.Permission", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DomainModels.General.Role", b =>
                {
                    b.HasOne("DomainModels.General.Role", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
