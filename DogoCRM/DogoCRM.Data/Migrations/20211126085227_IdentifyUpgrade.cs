using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogoCRM.Data.Migrations
{
    public partial class IdentifyUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 26, 11, 52, 27, 237, DateTimeKind.Local).AddTicks(1511), new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1693), new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1698) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1700), new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1703), new DateTime(2021, 11, 26, 11, 52, 27, 238, DateTimeKind.Local).AddTicks(1704) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 21, 19, 43, 47, 116, DateTimeKind.Local).AddTicks(5839), new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6824), new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6832), new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6835), new DateTime(2021, 11, 21, 19, 43, 47, 117, DateTimeKind.Local).AddTicks(6836) });
        }
    }
}
