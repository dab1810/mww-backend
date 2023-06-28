﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using team_scriptslingers_backend.Migrations;

#nullable disable

namespace team_scriptslingers_backend.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20230628005726_updated")]
    partial class updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

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
                        .HasColumnType("TEXT");

                    b.Property<bool?>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("userId");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
