using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateQuotesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ts = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Bid = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Ask = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Mid = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(564), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(565) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(567), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(568) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(569), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(571), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(574), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(574) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(576), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(578), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(579) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(581) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(582), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(584), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(325), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(386) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(391), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(392) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(394), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(396), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(398), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(401), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(402) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(403), new DateTime(2024, 6, 23, 18, 53, 19, 338, DateTimeKind.Local).AddTicks(404) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1386), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1389), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1391), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1393), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1396), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1396) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1398), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1399) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1400), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1402), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1403) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1404), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "InstrumentPairs",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1406), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1211), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1263), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1266), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1267) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1268), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1269) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1271), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1271) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1273), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1274) });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1275), new DateTime(2024, 6, 22, 15, 28, 24, 695, DateTimeKind.Local).AddTicks(1276) });
        }
    }
}
