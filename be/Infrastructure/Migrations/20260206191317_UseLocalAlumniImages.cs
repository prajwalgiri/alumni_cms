using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UseLocalAlumniImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 6, 19, 13, 15, 254, DateTimeKind.Utc).AddTicks(9502),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 6, 19, 5, 29, 415, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("040c1671-8008-4373-a8fc-271e6890eaef"),
                column: "profile_image_url",
                value: "/assets/alumni/230724m2q4sicJw9ukuqW13tUzbgZB1pdiRLiuMMeVvtT0.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("2018318d-1806-4909-89a0-023157e66719"),
                column: "profile_image_url",
                value: "/assets/alumni/230824FC3p60guGsbQgzdHEf2KD5sMrikr61guyIb7MriU.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3db7aba6-7d56-49b6-aa0f-94bfa983dfeb"),
                column: "profile_image_url",
                value: "/assets/alumni/230744SuzF29NWTbjx7HBKPZGTYcnyfkbb6HIzfRBd5pw0.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3f2805ce-a319-43ee-89f6-ab4f9ce2400f"),
                column: "profile_image_url",
                value: "/assets/alumni/250546VKQkQDtndyp4ZS7FVAZJBTlyQmVQgVkv0hIqO1ij.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("4c8ff2c7-12b3-4221-a90e-6ef5e1f28de5"),
                column: "profile_image_url",
                value: "/assets/alumni/230754Dzg5yB66hFc8H2EvdwnNlU5uHvbGSmYcwxQ0nZZp.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("53fbb707-3dc7-4723-ad48-957f58c35eaa"),
                column: "profile_image_url",
                value: "/assets/alumni/230726RVftrcSYYvDxNl5EOR9ZywIkL2gaSDu9iEbkBywD.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("60031424-d223-4879-b28a-bedbc6145b3d"),
                column: "profile_image_url",
                value: "/assets/alumni/2307015CrcA60NoIF75HWklcOnQjlI4oGZEeoPyKZnMvD0.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("6cd3db2d-4bb6-4693-999c-d3a02298271e"),
                column: "profile_image_url",
                value: "/assets/alumni/260130cMuobOb7fU99qcjY1hd7ysVmjagS9Ou8ETWr1wfJ.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("a1eb8095-d5b8-49c4-89a2-95ef3539879c"),
                column: "profile_image_url",
                value: "/assets/alumni/230737KbmeeEeKIqDfSvKv9Sm3UTkGA8SqDDcINndQiIyj.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b4b8ee97-6874-4089-946f-ef03e030c265"),
                column: "profile_image_url",
                value: "/assets/alumni/230708doIrG9ehcGUxX7l1eBGcm1k7AvNko3qd8GT3uJSy.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b71da4ec-f0e0-41c6-a051-06ec2de3ec3a"),
                column: "profile_image_url",
                value: "/assets/alumni/2307443y7Oa8YaGyBJTCDSTtbfYh3woN3UoY3gcua3gBT8.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b91027c1-cccd-4963-b9cf-80c90962349e"),
                column: "profile_image_url",
                value: "/assets/alumni/230749AahWf0XDDBeTaY2GJXb7WHbsNHEnrcFuKQPOKQ7l.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("d889db9a-784d-40b5-8b9f-640431ad0970"),
                column: "profile_image_url",
                value: "/assets/alumni/230711TU3VafOtLh5aRPPnE7K7khxxsdYAW4f0TZ55rTmz.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 6, 19, 5, 29, 415, DateTimeKind.Utc).AddTicks(1475),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 6, 19, 13, 15, 254, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("040c1671-8008-4373-a8fc-271e6890eaef"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230724m2q4sicJw9ukuqW13tUzbgZB1pdiRLiuMMeVvtT0.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("2018318d-1806-4909-89a0-023157e66719"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230824FC3p60guGsbQgzdHEf2KD5sMrikr61guyIb7MriU.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3db7aba6-7d56-49b6-aa0f-94bfa983dfeb"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230744SuzF29NWTbjx7HBKPZGTYcnyfkbb6HIzfRBd5pw0.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3f2805ce-a319-43ee-89f6-ab4f9ce2400f"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/250546VKQkQDtndyp4ZS7FVAZJBTlyQmVQgVkv0hIqO1ij.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("4c8ff2c7-12b3-4221-a90e-6ef5e1f28de5"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230754Dzg5yB66hFc8H2EvdwnNlU5uHvbGSmYcwxQ0nZZp.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("53fbb707-3dc7-4723-ad48-957f58c35eaa"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230726RVftrcSYYvDxNl5EOR9ZywIkL2gaSDu9iEbkBywD.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("60031424-d223-4879-b28a-bedbc6145b3d"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/2307015CrcA60NoIF75HWklcOnQjlI4oGZEeoPyKZnMvD0.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("6cd3db2d-4bb6-4693-999c-d3a02298271e"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/260130cMuobOb7fU99qcjY1hd7ysVmjagS9Ou8ETWr1wfJ.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("a1eb8095-d5b8-49c4-89a2-95ef3539879c"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230737KbmeeEeKIqDfSvKv9Sm3UTkGA8SqDDcINndQiIyj.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b4b8ee97-6874-4089-946f-ef03e030c265"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230708doIrG9ehcGUxX7l1eBGcm1k7AvNko3qd8GT3uJSy.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b71da4ec-f0e0-41c6-a051-06ec2de3ec3a"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/2307443y7Oa8YaGyBJTCDSTtbfYh3woN3UoY3gcua3gBT8.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b91027c1-cccd-4963-b9cf-80c90962349e"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230749AahWf0XDDBeTaY2GJXb7WHbsNHEnrcFuKQPOKQ7l.jpg");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("d889db9a-784d-40b5-8b9f-640431ad0970"),
                column: "profile_image_url",
                value: "https://saim.edu.np/storage/uploads/alumni/230711TU3VafOtLh5aRPPnE7K7khxxsdYAW4f0TZ55rTmz.jpg");
        }
    }
}
