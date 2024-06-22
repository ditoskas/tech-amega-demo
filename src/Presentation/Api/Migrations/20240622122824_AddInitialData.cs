using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "Symbol", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1211), "Euro", "/img/instruments/eur.png", "EUR", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1259) },
                    { 2L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1263), "United States Dollar", "/img/instruments/usd.png", "USD", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1264) },
                    { 3L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1266), "Bitcoin", "/img/instruments/btc.png", "BTC", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1267) },
                    { 4L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1268), "Ethereum", "/img/instruments/eth.png", "ETH", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1269) },
                    { 5L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1271), "Ripple", "/img/instruments/xrp.png", "XRP", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1271) },
                    { 6L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1273), "Bitcoin Cash", "/img/instruments/bch.png", "BCH", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1274) },
                    { 7L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1275), "Light Coin", "/img/instruments/ltc.png", "LTC", new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1276) }
                });

            migrationBuilder.InsertData(
                table: "InstrumentPairs",
                columns: new[] { "Id", "BaseInstrumentId", "CreatedAt", "NonBaseInstrumentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 3L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1386), 1L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1387) },
                    { 2L, 3L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1389), 2L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1390) },
                    { 3L, 4L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1391), 1L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1392) },
                    { 4L, 4L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1393), 2L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1394) },
                    { 5L, 5L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1396), 1L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1396) },
                    { 6L, 5L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1398), 2L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1399) },
                    { 7L, 6L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1400), 1L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1401) },
                    { 8L, 6L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1402), 2L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1403) },
                    { 9L, 7L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1404), 1L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1405) },
                    { 10L, 7L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1406), 2L, new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1407) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
