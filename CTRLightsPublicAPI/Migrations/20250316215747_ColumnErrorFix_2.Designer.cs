﻿// <auto-generated />
using System;
using CTRLightsPublicAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CTRLightsPublicAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250316215747_ColumnErrorFix_2")]
    partial class ColumnErrorFix_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CTRLightsPublicAPI.Data.Models.AdminUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("CTRLightsPublicAPI.Data.Models.AirQuality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EspDeviceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EspDeviceId");

                    b.ToTable("AirQuality");
                });

            modelBuilder.Entity("CTRLightsPublicAPI.Data.Models.EspDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.HasKey("Id");

                    b.ToTable("EspDevice");
                });

            modelBuilder.Entity("CTRLightsPublicAPI.Data.Models.TrafficLights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("FreeLaneStatus")
                        .HasColumnType("boolean");

                    b.Property<int>("Lane")
                        .HasColumnType("integer");

                    b.Property<char>("LightStatus")
                        .HasColumnType("character(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("TrafficLights");
                });

            modelBuilder.Entity("CTRLightsPublicAPI.Data.Models.AirQuality", b =>
                {
                    b.HasOne("CTRLightsPublicAPI.Data.Models.EspDevice", "EspDevice")
                        .WithMany()
                        .HasForeignKey("EspDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EspDevice");
                });
#pragma warning restore 612, 618
        }
    }
}
