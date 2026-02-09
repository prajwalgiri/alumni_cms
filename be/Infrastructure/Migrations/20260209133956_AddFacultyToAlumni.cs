using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultyToAlumni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 9, 13, 39, 54, 283, DateTimeKind.Utc).AddTicks(722),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 13, 30, 7, 608, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "alumni",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("040c1671-8008-4373-a8fc-271e6890eaef"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("2018318d-1806-4909-89a0-023157e66719"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3db7aba6-7d56-49b6-aa0f-94bfa983dfeb"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3f2805ce-a319-43ee-89f6-ab4f9ce2400f"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("4c8ff2c7-12b3-4221-a90e-6ef5e1f28de5"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("53fbb707-3dc7-4723-ad48-957f58c35eaa"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("60031424-d223-4879-b28a-bedbc6145b3d"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("6cd3db2d-4bb6-4693-999c-d3a02298271e"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("a1eb8095-d5b8-49c4-89a2-95ef3539879c"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b4b8ee97-6874-4089-946f-ef03e030c265"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b71da4ec-f0e0-41c6-a051-06ec2de3ec3a"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b91027c1-cccd-4963-b9cf-80c90962349e"),
                column: "Faculty",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("d889db9a-784d-40b5-8b9f-640431ad0970"),
                column: "Faculty",
                value: "Management");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "alumni");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 13, 30, 7, 608, DateTimeKind.Utc).AddTicks(9228),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 9, 13, 39, 54, 283, DateTimeKind.Utc).AddTicks(722));
        }
    }
}
