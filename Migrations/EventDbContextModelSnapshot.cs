﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using team_scriptslingers_backend.Migrations;

#nullable disable

namespace team_scriptslingers_backend.Migrations
{
    [DbContext(typeof(EventDbContext))]
    partial class EventDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("team_scriptslingers_backend.Models.Comment", b =>
                {
                    b.Property<int>("commentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("commentContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("commenter")
                        .HasColumnType("TEXT");

                    b.Property<int>("postId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("postedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("commentId");

                    b.HasIndex("postId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("team_scriptslingers_backend.Models.Event", b =>
                {
                    b.Property<int>("eventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("attendeeList")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("eventTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("eventTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("hostName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFinished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("location")
                        .HasColumnType("TEXT");

                    b.HasKey("eventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            eventId = 1,
                            description = "This is the first scheduled event on the database",
                            eventTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            eventTitle = "Event number ONE",
                            hostName = "David",
                            isFinished = false
                        },
                        new
                        {
                            eventId = 2,
                            description = "This is the SECOND scheduled event on the database",
                            eventTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            eventTitle = "Event number TWO",
                            hostName = "Marina",
                            isFinished = false
                        },
                        new
                        {
                            eventId = 3,
                            description = "This is the THIRD scheduled event on the database",
                            eventTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            eventTitle = "Event number THREE",
                            hostName = "Joseph",
                            isFinished = false
                        });
                });

            modelBuilder.Entity("team_scriptslingers_backend.Models.Post", b =>
                {
                    b.Property<int>("postId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("hostName")
                        .HasColumnType("TEXT");

                    b.Property<string>("postContent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("postedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("postId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("team_scriptslingers_backend.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("enrolledIn")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("userId");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("team_scriptslingers_backend.Models.Comment", b =>
                {
                    b.HasOne("team_scriptslingers_backend.Models.Post", "post")
                        .WithMany("comments")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("team_scriptslingers_backend.Models.Post", b =>
                {
                    b.Navigation("comments");
                });
#pragma warning restore 612, 618
        }
    }
}
