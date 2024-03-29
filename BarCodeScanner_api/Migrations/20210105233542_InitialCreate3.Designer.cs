﻿// <auto-generated />
using System;
using BarCodeScanner_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BarCodeScanner_api.Migrations
{
    [DbContext(typeof(apiDBContext))]
    [Migration("20210105233542_InitialCreate3")]
    partial class InitialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("BarCodeScanner_api.Models.DeviceSetupModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ProductRecordsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductRecordsId");

                    b.ToTable("SetupModels");
                });

            modelBuilder.Entity("BarCodeScanner_api.Models.ProductRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BarCodeData")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataInsertDat")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ProductRecords");
                });

            modelBuilder.Entity("BarCodeScanner_api.Models.DeviceSetupModel", b =>
                {
                    b.HasOne("BarCodeScanner_api.Models.ProductRecords", null)
                        .WithMany("DeviceSetup")
                        .HasForeignKey("ProductRecordsId");
                });

            modelBuilder.Entity("BarCodeScanner_api.Models.ProductRecords", b =>
                {
                    b.Navigation("DeviceSetup");
                });
#pragma warning restore 612, 618
        }
    }
}
