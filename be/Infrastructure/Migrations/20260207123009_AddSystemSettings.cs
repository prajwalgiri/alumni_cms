using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 12, 30, 7, 721, DateTimeKind.Utc).AddTicks(4480),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 6, 19, 13, 15, 254, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.CreateTable(
                name: "system_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    key = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_settings", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "system_settings",
                columns: new[] { "id", "created_at", "description", "key", "updated_at", "value" },
                values: new object[] { new Guid("a0000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Active color theme for the application", "Theme", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "blue" });

            migrationBuilder.CreateIndex(
                name: "IX_system_settings_key",
                table: "system_settings",
                column: "key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "system_settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 6, 19, 13, 15, 254, DateTimeKind.Utc).AddTicks(9502),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 12, 30, 7, 721, DateTimeKind.Utc).AddTicks(4480));
        }
    }
}
