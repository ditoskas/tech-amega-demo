﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Instrument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Instruments");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1211),
                            Description = "Euro",
                            ImagePath = "/img/instruments/eur.png",
                            Symbol = "EUR",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1259)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1263),
                            Description = "United States Dollar",
                            ImagePath = "/img/instruments/usd.png",
                            Symbol = "USD",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1264)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1266),
                            Description = "Bitcoin",
                            ImagePath = "/img/instruments/btc.png",
                            Symbol = "BTC",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1267)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1268),
                            Description = "Ethereum",
                            ImagePath = "/img/instruments/eth.png",
                            Symbol = "ETH",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1269)
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1271),
                            Description = "Ripple",
                            ImagePath = "/img/instruments/xrp.png",
                            Symbol = "XRP",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1271)
                        },
                        new
                        {
                            Id = 6L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1273),
                            Description = "Bitcoin Cash",
                            ImagePath = "/img/instruments/bch.png",
                            Symbol = "BCH",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1274)
                        },
                        new
                        {
                            Id = 7L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1275),
                            Description = "Light Coin",
                            ImagePath = "/img/instruments/ltc.png",
                            Symbol = "LTC",
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1276)
                        });
                });

            modelBuilder.Entity("Entities.Models.InstrumentPair", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BaseInstrumentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("NonBaseInstrumentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BaseInstrumentId");

                    b.HasIndex("NonBaseInstrumentId");

                    b.ToTable("InstrumentPairs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BaseInstrumentId = 3L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1386),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1387)
                        },
                        new
                        {
                            Id = 2L,
                            BaseInstrumentId = 3L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1389),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1390)
                        },
                        new
                        {
                            Id = 3L,
                            BaseInstrumentId = 4L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1391),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1392)
                        },
                        new
                        {
                            Id = 4L,
                            BaseInstrumentId = 4L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1393),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1394)
                        },
                        new
                        {
                            Id = 5L,
                            BaseInstrumentId = 5L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1396),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1396)
                        },
                        new
                        {
                            Id = 6L,
                            BaseInstrumentId = 5L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1398),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1399)
                        },
                        new
                        {
                            Id = 7L,
                            BaseInstrumentId = 6L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1400),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1401)
                        },
                        new
                        {
                            Id = 8L,
                            BaseInstrumentId = 6L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1402),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1403)
                        },
                        new
                        {
                            Id = 9L,
                            BaseInstrumentId = 7L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1404),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1405)
                        },
                        new
                        {
                            Id = 10L,
                            BaseInstrumentId = 7L,
                            CreatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1406),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1407)
                        });
                });

            modelBuilder.Entity("Entities.Models.InstrumentPair", b =>
                {
                    b.HasOne("Entities.Models.Instrument", "BaseInstrument")
                        .WithMany()
                        .HasForeignKey("BaseInstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Instrument", "NonBaseInstrument")
                        .WithMany()
                        .HasForeignKey("NonBaseInstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseInstrument");

                    b.Navigation("NonBaseInstrument");
                });
#pragma warning restore 612, 618
        }
    }
}
