﻿// <auto-generated />
using System;
using ElectronicDiary.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicDiary.Infrastucture.Migrations
{
    [DbContext(typeof(ElectronicDiaryDbContext))]
    partial class ElectronicDiaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId")
                        .IsUnique()
                        .HasFilter("[SchoolId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("WriteGrade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeTemplateId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.GradeTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GradeSign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GradeValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("GradeTemplates");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Address", b =>
                {
                    b.HasOne("ElectronicDiary.Domain.Entities.School", "School")
                        .WithOne("Address")
                        .HasForeignKey("ElectronicDiary.Domain.Entities.Address", "SchoolId");

                    b.Navigation("School");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Grade", b =>
                {
                    b.HasOne("ElectronicDiary.Domain.Entities.GradeTemplate", "Template")
                        .WithMany("Grades")
                        .HasForeignKey("GradeTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicDiary.Domain.Entities.Student", "Student")
                        .WithMany("Grade")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicDiary.Domain.Entities.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Student", b =>
                {
                    b.HasOne("ElectronicDiary.Domain.Entities.Address", "Address")
                        .WithOne("Student")
                        .HasForeignKey("ElectronicDiary.Domain.Entities.Student", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Address", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.GradeTemplate", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.School", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Student", b =>
                {
                    b.Navigation("Grade");
                });

            modelBuilder.Entity("ElectronicDiary.Domain.Entities.Subject", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
