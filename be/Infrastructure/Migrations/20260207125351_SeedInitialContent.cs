using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 12, 53, 49, 574, DateTimeKind.Utc).AddTicks(1118),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 12, 53, 2, 185, DateTimeKind.Utc).AddTicks(642));

            migrationBuilder.InsertData(
                table: "contents",
                columns: new[] { "id", "body", "created_at", "created_by", "publish_date", "status", "title", "type", "updated_at" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), "We are excited to launch our new portal to help our alumni stay connected. Explore the features and update your profile!", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Welcome to the new Alumni Portal!", 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), "Don't forget to register for the upcoming annual meetup in December. We have some great speakers lined up!", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Upcoming Annual Meetup", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), "Join our career services workshop next week to learn about the latest industry trends and how to improve your resume.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Career Services Workshop", 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contents",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "contents",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "contents",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 7, 12, 53, 2, 185, DateTimeKind.Utc).AddTicks(642),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 7, 12, 53, 49, 574, DateTimeKind.Utc).AddTicks(1118));
        }
    }
}
