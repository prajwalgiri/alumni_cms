using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSystemSettingsStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "system_settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "General");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 12, 56, 33, 595, DateTimeKind.Utc).AddTicks(9975),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 12, 49, 24, 806, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "system_settings",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "type", "value" },
                values: new object[] { "UI", "maroon" });

            migrationBuilder.InsertData(
                table: "system_settings",
                columns: new[] { "id", "created_at", "description", "key", "type", "updated_at", "value" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Global application logo", "LogoUrl", "Branding", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/logo.png" },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Application favicon", "FaviconUrl", "Branding", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "/favicon.ico" },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The name of the application", "SiteName", "General", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Alumni Network" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "system_settings",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "system_settings",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "system_settings",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DropColumn(
                name: "type",
                table: "system_settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 12, 49, 24, 806, DateTimeKind.Utc).AddTicks(2476),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 12, 56, 33, 595, DateTimeKind.Utc).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "system_settings",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                column: "value",
                value: "blue");
        }
    }
}
