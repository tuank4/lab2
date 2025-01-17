﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab02.Data;

#nullable disable

namespace lab02.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("lab02.Models.Courses", b =>
                {
                    b.Property<Guid>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            CName = "J.K. Rowling",
                            Desciption = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs."
                        },
                        new
                        {
                            CId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                            CName = "Walter Isaacson",
                            Desciption = "Harry Potter's life is miserable. His parents are dead"
                        });
                });

            modelBuilder.Entity("lab02.Models.Student", b =>
                {
                    b.Property<Guid>("StId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                            Name = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            StId = new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                            Name = "Harry Chamber "
                        },
                        new
                        {
                            StId = new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                            Name = "Steve Jobs"
                        });
                });

            modelBuilder.Entity("lab02.Models.StudentCourse", b =>
                {
                    b.Property<Guid>("StId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StId", "CId");

                    b.HasIndex("CId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                            CId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59")
                        },
                        new
                        {
                            StId = new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                            CId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd")
                        });
                });

            modelBuilder.Entity("lab02.Models.StudentCourse", b =>
                {
                    b.HasOne("lab02.Models.Courses", "Courses")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab02.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("lab02.Models.Courses", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("lab02.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
