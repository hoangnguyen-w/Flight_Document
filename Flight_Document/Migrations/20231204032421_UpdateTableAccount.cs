using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Document.Migrations
{
    public partial class UpdateTableAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("5bd8acbb-fc63-47df-8fe1-6928c05bdb20"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("5ea846a2-6f08-450b-8911-c41d4c7ae40a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("69237d00-cde9-4bd1-ae5c-2d5252a733b3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("77554e78-b1ac-413a-862f-513995dc2ba4"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenCreated",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("00ed25ec-76c3-4015-be70-08a790097bfa"), "Staff" },
                    { new Guid("3ee909e3-05b1-41a2-b6ad-5e496ea411ae"), "Pilot" },
                    { new Guid("46118d1e-f265-434c-93d6-b9ce999c1a52"), "Stewardess" },
                    { new Guid("987dc002-2098-457c-80b3-c76cdc11093a"), "Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("00ed25ec-76c3-4015-be70-08a790097bfa"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("3ee909e3-05b1-41a2-b6ad-5e496ea411ae"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("46118d1e-f265-434c-93d6-b9ce999c1a52"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("987dc002-2098-457c-80b3-c76cdc11093a"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "TokenCreated",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "Account");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5bd8acbb-fc63-47df-8fe1-6928c05bdb20"), "Pilot" },
                    { new Guid("5ea846a2-6f08-450b-8911-c41d4c7ae40a"), "Stewardess" },
                    { new Guid("69237d00-cde9-4bd1-ae5c-2d5252a733b3"), "Staff" },
                    { new Guid("77554e78-b1ac-413a-862f-513995dc2ba4"), "Admin" }
                });
        }
    }
}
