﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalksAPI.Core.Databases;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace NZWalksAPI.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20240318065833_Seeding data")]
    partial class Seedingdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalksAPI.Core.Models.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd502112-a322-4092-a458-5d332db054ec"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("a9648a0a-9d67-4f3e-a7c8-0d9d601a3396"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("7f9058ca-1123-4f7a-95fb-42be587e2722"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Core.Models.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0447bc9c-ce4b-4019-882e-355d8f6686f4"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://bit.ly/3VpbtMS"
                        },
                        new
                        {
                            Id = new Guid("a3c2db25-b582-4cd4-8d10-2c1ab984e2c9"),
                            Code = "BOP",
                            Name = "Bay Of Plenty"
                        },
                        new
                        {
                            Id = new Guid("4c218e45-068d-4bc2-b346-74eec5466661"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "https://bit.ly/4aeiB2Q"
                        },
                        new
                        {
                            Id = new Guid("829de7fe-8a55-4f70-9f5d-adab12215f51"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "https://bit.ly/49VT2E6"
                        },
                        new
                        {
                            Id = new Guid("ac601f69-b2f9-473e-a168-cf11a722a655"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "null"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Core.Models.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("RAW(16)");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalksAPI.Core.Models.Walk", b =>
                {
                    b.HasOne("NZWalksAPI.Core.Models.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalksAPI.Core.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
