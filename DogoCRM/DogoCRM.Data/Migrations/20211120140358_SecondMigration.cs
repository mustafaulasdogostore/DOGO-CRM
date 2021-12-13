using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogoCRM.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsPlanned",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ImportanceLevel",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportanceLevel",
                table: "Requests");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPlanned",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 13, 16, 30, 884, DateTimeKind.Local).AddTicks(8462), new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(1120), new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(1125) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(1126), new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(1128) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(1129), new DateTime(2021, 11, 20, 13, 16, 30, 886, DateTimeKind.Local).AddTicks(1131) });
        }
    }
}
