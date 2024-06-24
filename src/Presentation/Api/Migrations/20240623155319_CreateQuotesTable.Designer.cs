﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240623155319_CreateQuotesTable")]
    partial class CreateQuotesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(325),
                            Description = "Euro",
                            ImagePath = "/img/instruments/eur.png",
                            Symbol = "EUR",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(386)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(391),
                            Description = "United States Dollar",
                            ImagePath = "/img/instruments/usd.png",
                            Symbol = "USD",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(392)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(394),
                            Description = "Bitcoin",
                            ImagePath = "/img/instruments/btc.png",
                            Symbol = "BTC",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(395)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(396),
                            Description = "Ethereum",
                            ImagePath = "/img/instruments/eth.png",
                            Symbol = "ETH",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(397)
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(398),
                            Description = "Ripple",
                            ImagePath = "/img/instruments/xrp.png",
                            Symbol = "XRP",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(399)
                        },
                        new
                        {
                            Id = 6L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(401),
                            Description = "Bitcoin Cash",
                            ImagePath = "/img/instruments/bch.png",
                            Symbol = "BCH",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(402)
                        },
                        new
                        {
                            Id = 7L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(403),
                            Description = "Light Coin",
                            ImagePath = "/img/instruments/ltc.png",
                            Symbol = "LTC",
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(404)
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
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(564),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(565)
                        },
                        new
                        {
                            Id = 2L,
                            BaseInstrumentId = 3L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(567),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(568)
                        },
                        new
                        {
                            Id = 3L,
                            BaseInstrumentId = 4L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(569),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(570)
                        },
                        new
                        {
                            Id = 4L,
                            BaseInstrumentId = 4L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(571),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(572)
                        },
                        new
                        {
                            Id = 5L,
                            BaseInstrumentId = 5L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(574),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(574)
                        },
                        new
                        {
                            Id = 6L,
                            BaseInstrumentId = 5L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(576),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(576)
                        },
                        new
                        {
                            Id = 7L,
                            BaseInstrumentId = 6L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(578),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(579)
                        },
                        new
                        {
                            Id = 8L,
                            BaseInstrumentId = 6L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(580),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(581)
                        },
                        new
                        {
                            Id = 9L,
                            BaseInstrumentId = 7L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(582),
                            NonBaseInstrumentId = 1L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(583)
                        },
                        new
                        {
                            Id = 10L,
                            BaseInstrumentId = 7L,
                            CreatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(584),
                            NonBaseInstrumentId = 2L,
                            UpdatedAt = new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(585)
                        });
                });

            modelBuilder.Entity("Entities.Models.Quote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Ask")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Bid")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Mid")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("Ts")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Quotes");
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
