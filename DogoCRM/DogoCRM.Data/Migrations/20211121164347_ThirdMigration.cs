using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogoCRM.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 17, 3, 58, 131, DateTimeKind.Local).AddTicks(6452), new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(7275), new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(7282), new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(7285), new DateTime(2021, 11, 20, 17, 3, 58, 132, DateTimeKind.Local).AddTicks(7286) });
        }
    }
}
