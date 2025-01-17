﻿// <auto-generated />
using System;
using App_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240823055518_UpdateDB")]
    partial class UpdateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App_Data.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("App_Data.Entities.Department_Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDepartment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHeadOfDepartment")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Department_Facility");
                });

            modelBuilder.Entity("App_Data.Entities.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("App_Data.Entities.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("App_Data.Entities.Major_Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDepartmentFacility")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMajor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("department_FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.HasIndex("department_FacilityId");

                    b.ToTable("Major_Facility");
                });

            modelBuilder.Entity("App_Data.Entities.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountFE")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountFPT")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountFE")
                        .IsUnique();

                    b.HasIndex("AccountFPT")
                        .IsUnique();

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("App_Data.Entities.Staff_MajorFacility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMajorFacility")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdStaff")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("major_FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.HasIndex("major_FacilityId");

                    b.ToTable("Staff_Major");
                });

            modelBuilder.Entity("App_Data.Entities.Department_Facility", b =>
                {
                    b.HasOne("App_Data.Entities.Department", "Department")
                        .WithMany("Department_Facilities")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_Data.Entities.Facility", "Facility")
                        .WithMany("Department_Facilities")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("App_Data.Entities.Major_Facility", b =>
                {
                    b.HasOne("App_Data.Entities.Major", "Major")
                        .WithMany("Major_Facilities")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_Data.Entities.Department_Facility", "department_Facility")
                        .WithMany("Major_Facilities")
                        .HasForeignKey("department_FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");

                    b.Navigation("department_Facility");
                });

            modelBuilder.Entity("App_Data.Entities.Staff_MajorFacility", b =>
                {
                    b.HasOne("App_Data.Entities.Staff", "Staff")
                        .WithMany("Staff_Majors")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_Data.Entities.Major_Facility", "major_Facility")
                        .WithMany("Staff_Majors")
                        .HasForeignKey("major_FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");

                    b.Navigation("major_Facility");
                });

            modelBuilder.Entity("App_Data.Entities.Department", b =>
                {
                    b.Navigation("Department_Facilities");
                });

            modelBuilder.Entity("App_Data.Entities.Department_Facility", b =>
                {
                    b.Navigation("Major_Facilities");
                });

            modelBuilder.Entity("App_Data.Entities.Facility", b =>
                {
                    b.Navigation("Department_Facilities");
                });

            modelBuilder.Entity("App_Data.Entities.Major", b =>
                {
                    b.Navigation("Major_Facilities");
                });

            modelBuilder.Entity("App_Data.Entities.Major_Facility", b =>
                {
                    b.Navigation("Staff_Majors");
                });

            modelBuilder.Entity("App_Data.Entities.Staff", b =>
                {
                    b.Navigation("Staff_Majors");
                });
#pragma warning restore 612, 618
        }
    }
}
