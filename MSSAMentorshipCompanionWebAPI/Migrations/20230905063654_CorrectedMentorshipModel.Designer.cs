﻿// <auto-generated />
using System;
using MSSAMentorshipCompanionWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSSAMentorshipCompanionWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230905063654_CorrectedMentorshipModel")]
    partial class CorrectedMentorshipModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.ChatMessage", b =>
                {
                    b.Property<int>("ChatMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatMessageId"));

                    b.Property<int?>("ChatThreadThreadId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.HasKey("ChatMessageId");

                    b.HasIndex("ChatThreadThreadId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.ChatThread", b =>
                {
                    b.Property<int>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThreadId"));

                    b.HasKey("ThreadId");

                    b.ToTable("ChatThreads");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoalId"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GoalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoalDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoalThreadThreadId")
                        .HasColumnType("int");

                    b.Property<int>("MentorshipId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GoalId");

                    b.HasIndex("GoalThreadThreadId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.Mentorship", b =>
                {
                    b.Property<int>("MentorshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MentorshipId"));

                    b.Property<string>("MentorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MentorshipId");

                    b.ToTable("Mentorships");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.UserCredentials", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NeedPasswordReset")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.UserProfile", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.ChatMessage", b =>
                {
                    b.HasOne("MSSAMentorshipCompanionWebAPI.Models.ChatThread", null)
                        .WithMany("ChatMessages")
                        .HasForeignKey("ChatThreadThreadId");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.Goal", b =>
                {
                    b.HasOne("MSSAMentorshipCompanionWebAPI.Models.ChatThread", "GoalThread")
                        .WithMany()
                        .HasForeignKey("GoalThreadThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoalThread");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.UserProfile", b =>
                {
                    b.HasOne("MSSAMentorshipCompanionWebAPI.Models.UserCredentials", "UserCredentials")
                        .WithOne("UserProfile")
                        .HasForeignKey("MSSAMentorshipCompanionWebAPI.Models.UserProfile", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCredentials");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.ChatThread", b =>
                {
                    b.Navigation("ChatMessages");
                });

            modelBuilder.Entity("MSSAMentorshipCompanionWebAPI.Models.UserCredentials", b =>
                {
                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
