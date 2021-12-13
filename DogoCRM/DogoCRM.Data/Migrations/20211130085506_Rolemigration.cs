using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogoCRM.Data.Migrations
{
    public partial class Rolemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "7e9121aa-a20f-46f6-8b09-098e5117c478", "Admin", "ADMIN" },
                    { 2, "8c385ba5-e037-411b-8ad2-775b64e939ac", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 30, 11, 55, 5, 820, DateTimeKind.Local).AddTicks(9899), new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(8020), new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(8033), new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(8034) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(8037), new DateTime(2021, 11, 30, 11, 55, 5, 822, DateTimeKind.Local).AddTicks(8039) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 8 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
