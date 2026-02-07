using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnableSettingsNavigationForAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 13, 30, 7, 608, DateTimeKind.Utc).AddTicks(9228),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 12, 58, 44, 816, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000036"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000017"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000037"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000038"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000039"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000040"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000041"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000007"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000042"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000008"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000043"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000010"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000044"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000013"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000045"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000046"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000047"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000048"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000049"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000009"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000050"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000010"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000051"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000011"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000052"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000012"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000053"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000054"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000055"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000056"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000004"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000057"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000058"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000059"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000060"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000061"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000005"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000062"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000006"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000063"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000007"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000064"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000008"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000065"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000009"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000066"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000010"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000067"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000011"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000068"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000012"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000069"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000013"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000070"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000014"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000071"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000015"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000072"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000016"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000073"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000017"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000074"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000018"));

            migrationBuilder.InsertData(
                table: "role_navigation",
                columns: new[] { "id", "created_at", "navigation_item_id", "role_id", "UpdatedAt" },
                values: new object[] { new Guid("00000000-0000-0000-2222-000000000075"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000019"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000075"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 12, 58, 44, 816, DateTimeKind.Utc).AddTicks(1768),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 13, 30, 7, 608, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000036"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000037"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000038"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000039"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000040"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000007"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000041"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000008"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000042"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000010"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000043"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000013"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000044"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000045"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000046"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000047"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000048"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000009"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000049"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000010"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000050"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000011"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000051"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000012"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000052"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000053"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000054"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000055"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000056"),
                columns: new[] { "navigation_item_id", "role_id" },
                values: new object[] { new Guid("90000000-0000-0000-0000-000000000001"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000057"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000058"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000059"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000004"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000060"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000005"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000061"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000006"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000062"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000007"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000063"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000008"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000064"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000009"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000065"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000010"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000066"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000011"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000067"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000012"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000068"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000013"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000069"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000014"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000070"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000015"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000071"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000016"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000072"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000017"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000073"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000018"));

            migrationBuilder.UpdateData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000074"),
                column: "navigation_item_id",
                value: new Guid("90000000-0000-0000-0000-000000000019"));
        }
    }
}
