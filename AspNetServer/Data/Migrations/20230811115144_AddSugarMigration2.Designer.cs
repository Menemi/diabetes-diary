﻿// <auto-generated />
using System;
using AspNetServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetServer.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230811115144_AddSugarMigration2")]
    partial class AddSugarMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("AspNetServer.Data.Classes.SugarClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("InsulinIncreased")
                        .HasColumnType("REAL");

                    b.Property<double>("Sugar")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sugars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InsulinIncreased = 0.0,
                            Sugar = 5.0999999999999996,
                            Time = new DateTime(2023, 8, 11, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1638)
                        },
                        new
                        {
                            Id = 2,
                            InsulinIncreased = 0.0,
                            Sugar = 5.2000000000000002,
                            Time = new DateTime(2023, 8, 10, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1644)
                        },
                        new
                        {
                            Id = 3,
                            InsulinIncreased = 0.0,
                            Sugar = 5.2999999999999998,
                            Time = new DateTime(2023, 8, 9, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1647)
                        },
                        new
                        {
                            Id = 4,
                            InsulinIncreased = 0.0,
                            Sugar = 5.4000000000000004,
                            Time = new DateTime(2023, 8, 8, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1649)
                        },
                        new
                        {
                            Id = 5,
                            InsulinIncreased = 0.0,
                            Sugar = 5.5,
                            Time = new DateTime(2023, 8, 7, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1651)
                        },
                        new
                        {
                            Id = 6,
                            InsulinIncreased = 0.0,
                            Sugar = 5.5999999999999996,
                            Time = new DateTime(2023, 8, 6, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1653)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
