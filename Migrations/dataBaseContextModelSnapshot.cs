﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using studyProject.Data;

#nullable disable

namespace task_manager.Migrations
{
    [DbContext(typeof(dataBaseContext))]
    partial class dataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("task_manager.Models.CollaboratorsModel", b =>
                {
                    b.Property<long>("IDCollaborator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDCollaborator"), 1L, 1);

                    b.Property<DateTime>("dtmCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmDeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("vchCollaboratorName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IDCollaborator");

                    b.ToTable("tCollaborator");
                });

            modelBuilder.Entity("task_manager.Models.ProjectModel", b =>
                {
                    b.Property<long>("IDProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDProject"), 1L, 1);

                    b.Property<DateTime>("dtmCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmDeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("vchProjectName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IDProject");

                    b.ToTable("tProject");
                });

            modelBuilder.Entity("task_manager.Models.TaskCollaboratorModel", b =>
                {
                    b.Property<long>("IDTaskCollaborator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDTaskCollaborator"), 1L, 1);

                    b.Property<long>("IDCollaborator")
                        .HasColumnType("bigint");

                    b.Property<long>("IDTask")
                        .HasColumnType("bigint");

                    b.HasKey("IDTaskCollaborator");

                    b.HasIndex("IDCollaborator");

                    b.HasIndex("IDTask");

                    b.ToTable("tTaskCollaborator");
                });

            modelBuilder.Entity("task_manager.Models.TasksModel", b =>
                {
                    b.Property<long>("IDTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDTask"), 1L, 1);

                    b.Property<long>("IDProject")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("dtmCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmDeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("vchDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vchTaskName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IDTask");

                    b.HasIndex("IDProject");

                    b.ToTable("tTask");
                });

            modelBuilder.Entity("task_manager.Models.TimeTrackersModel", b =>
                {
                    b.Property<long>("IDTimeTracker")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDTimeTracker"), 1L, 1);

                    b.Property<long>("IDCollaborator")
                        .HasColumnType("bigint");

                    b.Property<long>("IDTask")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("dtmCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmDeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtmEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtmStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("vchTimeZoneID")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IDTimeTracker");

                    b.HasIndex("IDCollaborator");

                    b.HasIndex("IDTask");

                    b.ToTable("tTimeTracker");
                });

            modelBuilder.Entity("task_manager.Models.UserModel", b =>
                {
                    b.Property<long>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IDUser"), 1L, 1);

                    b.Property<DateTime>("dtmCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmDeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dtmUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("vchPassword")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("vchUserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IDUser");

                    b.HasIndex("vchUserName")
                        .IsUnique();

                    b.ToTable("tUser");
                });

            modelBuilder.Entity("task_manager.Models.TaskCollaboratorModel", b =>
                {
                    b.HasOne("task_manager.Models.CollaboratorsModel", null)
                        .WithMany()
                        .HasForeignKey("IDCollaborator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task_manager.Models.TasksModel", null)
                        .WithMany()
                        .HasForeignKey("IDTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("task_manager.Models.TasksModel", b =>
                {
                    b.HasOne("task_manager.Models.ProjectModel", null)
                        .WithMany()
                        .HasForeignKey("IDProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("task_manager.Models.TimeTrackersModel", b =>
                {
                    b.HasOne("task_manager.Models.CollaboratorsModel", null)
                        .WithMany()
                        .HasForeignKey("IDCollaborator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task_manager.Models.TasksModel", null)
                        .WithMany()
                        .HasForeignKey("IDTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
