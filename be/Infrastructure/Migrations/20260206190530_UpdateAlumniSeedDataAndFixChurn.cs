using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alumni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlumniSeedDataAndFixChurn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("08e81a51-a147-4b46-9181-27e949a7373c"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("0bed420b-4809-4b55-b3bc-ac93628d1fba"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("0f186ed8-a0cf-4609-a7ce-1649cf8241fb"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("1b585702-597b-4827-a7a6-690d61d853e2"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("1c0ac468-9f80-4d0b-99dd-00fefe2bcdac"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("21229c46-8bf2-47d9-a1a9-c10efca8a238"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("219b5043-69ca-4597-875f-f06c46ebd3a9"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("2496e09e-c106-4fd1-90fb-e5dbb7c7b9d3"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("2833fdeb-720f-47ab-b78c-8da222e80674"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("2afaea7e-cb71-4d44-9a49-1c48e3fa8013"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("31b122a8-ca69-4003-8455-011e6c2718af"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("327553ff-c005-4ab9-91d6-8159183f0ae6"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("33a07776-f285-4cef-81b1-7c4bc6dfdd32"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("34ced13f-19c9-4f7c-bf1c-3b05b67869ca"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("36e641b4-d5fb-44fa-b5f3-4aeac6631320"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("3a7341f3-662e-448f-b2cc-f3b3cb116278"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("4a9fdde0-03bc-46f4-925d-9178041f284a"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("5288f959-5f67-49c0-ade4-4e53bbaaef0f"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("56284bd9-5873-4a17-80ad-72c6d79b91cb"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("586af558-1f83-4418-a4ad-f799ab110c68"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("5dfa6000-f2cc-400a-bd52-4f9ed3d9a312"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("5e7afe93-a935-4a20-acfa-e9af9c62c119"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("64b29d58-40d1-4187-b675-e55028630dec"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("6770ae19-94fd-4227-990a-8468f31b52ef"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("6afbc2ae-f514-46ef-b22e-0948370ae16c"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("77bfa9d8-5465-48cb-b06e-0eac983064d5"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("803a2bb8-f9b4-4e29-8052-8d9f465342ec"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("85c83279-7edf-44be-b85e-1b492b27e825"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("8acf250e-369e-403d-b036-882955e0c872"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("905871d7-091b-46a9-b958-4df80a8d7baa"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("95d8d1d4-b169-4ff3-aaa8-f93f87416082"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("983d45df-8059-4385-b4d9-44c9a9581cb2"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("a6ed02b0-1d2d-4732-adfb-36c35a1fa28d"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("aaefc255-18ef-4c05-9d00-2041047028c6"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("ad478ac7-025b-4be4-98c0-fc4321e9299b"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("b21799e5-f349-4e33-8023-acb1d985d54a"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("b2a329dd-3995-44ea-ab18-93516815ee1c"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("bdea9181-504a-49e8-bbfb-d56de461dd24"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("bf26e29d-77a5-4e9c-9039-316aa8cdc933"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("ce02ac02-4f35-4e8c-a5a7-6cbc2cef191e"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("d300b455-911d-425f-b9da-9a071c3488e5"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("dd5ecc7a-9352-441e-8c7c-fe9cac03b13c"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("de04d351-e542-49ff-850d-b173deaa2ca1"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("eaf4a1b0-a811-4198-9596-8f14dd623921"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f006df8e-d243-4e77-adc2-2723f0678708"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f153b7a8-e504-4482-90da-9db9d464f51d"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f2fe8790-c109-4f90-a5cc-f38c647b56c4"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f3cded1c-60b7-419d-ab0c-2d5764618744"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f60e739e-e665-44b3-ac6d-f3055e67d404"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f895aaea-b113-421d-8a21-963db5cdfe22"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("f9fc7e51-8d89-43f5-8404-d15af692fe3a"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("fb24aeee-fe97-4004-b17e-adf79c73dece"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("fe0f6a6c-b3bd-4a47-a698-db9627bdece6"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("fe466335-336b-4efb-9d9a-535d53132d43"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("fedab0a7-20e2-43ce-b82f-413bc9b94b56"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("03a669f1-1c55-4727-bcb3-aca2d4329ea5"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("0693a8e2-aecd-4d2f-8a18-37217567da69"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("121f012a-80c4-49b2-a751-ac3342973c2c"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("14599bb6-02b6-45e4-a77f-7a99cdd1d44b"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("17adf084-d862-4899-94ad-731359fe0ecf"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("19da6304-a0f3-4e61-9aca-888233ac31ed"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("1bff6fce-82fb-4576-8244-f5d126d96dd1"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("1e0dc091-645b-460b-804f-1f0377d87010"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("27ae68c0-b7e5-49fe-93a7-27a0e3c53419"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("2a699bf1-35ff-43d2-83d5-675e34b96111"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("2c83aea9-8b1e-4f8c-9f09-a511a1cb4d57"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("2e8ced0c-14be-4c25-a72d-ea97e35d9fd1"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("2ec418bd-9191-4cba-a39f-5ececf3bf593"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("30108b3f-0874-428e-bf8c-84360e07869b"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("33fcda4b-b4b1-488a-9fcd-a3278fb02671"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("3e82ff25-4518-4d01-a637-64376b574a70"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("3f69cd8f-58c3-46b4-8371-043cee81fcfd"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("40d67713-ab22-490d-90eb-da2c90b4034c"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("47feda0e-cfd1-4987-9a12-51dbc1a4cf3e"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("4acef2d4-7735-4517-a7fc-4182aadbcbcc"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("4db7525f-e545-4e54-9d51-4333dfcb7af3"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("568528e3-1524-44c2-a6e1-c1f85b66fe31"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("58a822cf-4a52-46b2-92a5-cd1e6b8da9c7"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("63ed6117-2ca4-4b30-a189-7de2648b1dc8"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("641d9c93-17da-47ec-b309-bb7599e3db10"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("65459e0f-5bc7-4dca-9f52-fc581b82ec38"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("68be4787-8e9c-4b4d-8ce7-b5b04c9d115e"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("6a5e6f5f-41bc-4df5-b837-71dcbe14da07"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("6b49241c-c8b2-4d73-a232-671940f562b9"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("6d414036-35bf-4e29-ba8a-17b13305cd32"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("7201eff4-2480-4129-a993-114a6e4bc785"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("7240432e-fe87-426a-b721-ef3a2863b7fd"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("740401e0-28b4-4a1b-8526-ddc36745d03c"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("7550576d-755d-426e-9884-c0dfe6959d49"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("7d3e9415-6037-4674-85f5-b33fb02d7877"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("82889fe1-ebeb-413c-a1a2-9d598687c4b9"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("90d147e4-6270-4eb1-b653-a412b0f1c722"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("9156de16-6abd-4cfc-a521-a15012ff50a1"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("952a5edb-eee2-4a5b-b41b-792d988502b8"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("9667cbaa-aa79-4c61-b8fd-78ca5b73ebed"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("9753d04f-bef6-4e34-be28-6e287faec4ea"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("9e147443-25b9-4af6-9a09-6786b33bd0fc"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("9e263daf-7944-4f07-b483-da2c0a56cde5"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("a5a108bd-dff5-438c-a723-2c0b2d7b7170"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("ae971419-ad48-47b5-9c0b-8625aae122b9"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("bb8f4a82-bb7f-41f2-9174-b3077e8fcbd4"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("bdab3c5f-ebd8-44c9-b2b6-fb1438848d56"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("be47cdc8-5564-468f-8894-97e8ddeb2e53"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("c20ed225-f040-4912-baed-e61876f6b20f"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("cbe6b346-0789-43b3-811c-d397fc69c886"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("cc40b330-8ab2-4e0c-9a09-822153eade01"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("cda4c9bd-e8d3-4815-8cd5-05d093e41351"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("cf61b868-9113-4bd8-a1e8-d2d860229062"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("d927cc1e-3531-4857-baad-a91629b05ec5"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("e15b49b6-5b6f-4a05-bac9-db91c97f5601"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("e38e338d-2b9b-4f50-98fb-8d22b3ced05b"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("e714fe81-422b-4994-a31b-3a4f886072ba"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("ea727c6f-dd48-4a1c-a0bd-ec1d56eac940"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("eacf0ee8-1516-4ca6-b4d9-6cfc5378d2f1"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("eb76803d-1d5f-42a0-8217-bff236bb3faf"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("ed713d7f-4fe2-44ef-bdb7-7293429aac0d"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("f40c50ee-fb7b-47bf-8d27-3208a4078ee2"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("f92686c0-1993-4dc7-98cd-87c2d908b74d"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("f94b2319-a0a9-4e79-83b2-afad1c846528"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("f9b2c970-3a31-4a29-8cfd-fd926d05ccee"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("fd81443b-bf55-4c74-b3a0-cdbe2aa106f6"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("fdf10b47-befb-4a17-a0b3-637832e9ff65"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 6, 19, 5, 29, 415, DateTimeKind.Utc).AddTicks(1475),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 6, 18, 11, 54, 32, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("040c1671-8008-4373-a8fc-271e6890eaef"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("2018318d-1806-4909-89a0-023157e66719"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3db7aba6-7d56-49b6-aa0f-94bfa983dfeb"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3f2805ce-a319-43ee-89f6-ab4f9ce2400f"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("4c8ff2c7-12b3-4221-a90e-6ef5e1f28de5"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("53fbb707-3dc7-4723-ad48-957f58c35eaa"),
                column: "major",
                value: "Management (Spring)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("60031424-d223-4879-b28a-bedbc6145b3d"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("6cd3db2d-4bb6-4693-999c-d3a02298271e"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("a1eb8095-d5b8-49c4-89a2-95ef3539879c"),
                column: "major",
                value: "Management (Spring)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b4b8ee97-6874-4089-946f-ef03e030c265"),
                column: "major",
                value: "Management (Fall)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b71da4ec-f0e0-41c6-a051-06ec2de3ec3a"),
                column: "major",
                value: "Management (Spring)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b91027c1-cccd-4963-b9cf-80c90962349e"),
                column: "major",
                value: "Management (Spring)");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("d889db9a-784d-40b5-8b9f-640431ad0970"),
                column: "major",
                value: "Management (Spring)");

            migrationBuilder.InsertData(
                table: "role_navigation",
                columns: new[] { "id", "created_at", "navigation_item_id", "role_id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-2222-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000005"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000006"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000006"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000007"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000007"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000008"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000008"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000009"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000009"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000010"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000011"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000011"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000012"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000012"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000013"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000013"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000014"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000014"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000015"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000015"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000016"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000016"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000017"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000017"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000018"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000018"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000019"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000019"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000020"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000021"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000022"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000023"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000024"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000025"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000006"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000026"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000007"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000027"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000008"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000028"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000009"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000029"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000030"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000011"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000031"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000012"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000032"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000013"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000033"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000014"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000034"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000015"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000035"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000016"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000036"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000037"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000038"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000039"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000040"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000007"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000041"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000008"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000042"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000043"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000013"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000044"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000045"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000046"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000047"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000048"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000009"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000049"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000050"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000011"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000051"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000012"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000052"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000053"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000054"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-2222-000000000055"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "id", "created_at", "permission_id", "role_id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1111-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000005"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000006"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000007"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000008"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000009"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000010"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000011"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000012"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000013"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000014"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000015"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000016"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000017"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000018"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000019"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000020"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000021"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000022"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000023"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000024"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000025"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000026"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("70000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000027"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("70000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000028"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000029"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000030"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000031"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000032"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000033"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000034"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000035"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000036"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000037"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000038"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000039"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000040"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000041"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000042"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000043"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000044"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000045"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000046"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000047"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000048"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000049"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000050"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000002"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000051"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000052"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000053"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000054"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000055"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000056"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000057"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000058"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000059"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000060"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000061"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000062"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000063"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000064"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000065"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000066"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-1111-000000000067"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000001"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000002"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000003"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000004"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000005"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000006"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000007"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000008"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000009"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000010"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000011"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000012"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000013"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000014"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000015"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000016"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000017"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000018"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000019"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000020"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000021"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000022"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000023"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000024"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000025"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000026"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000027"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000028"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000029"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000030"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000031"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000032"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000033"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000034"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000035"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000036"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000037"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000038"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000039"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000040"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000041"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000042"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000043"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000044"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000045"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000046"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000047"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000048"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000049"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000050"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000051"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000052"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000053"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000054"));

            migrationBuilder.DeleteData(
                table: "role_navigation",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-2222-000000000055"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000001"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000002"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000003"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000004"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000005"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000006"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000007"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000008"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000009"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000010"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000011"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000012"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000013"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000014"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000015"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000016"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000017"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000018"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000019"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000020"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000021"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000022"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000023"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000024"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000025"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000026"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000027"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000028"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000029"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000030"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000031"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000032"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000033"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000034"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000035"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000036"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000037"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000038"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000039"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000040"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000041"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000042"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000043"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000044"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000045"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000046"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000047"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000048"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000049"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000050"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000051"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000052"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000053"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000054"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000055"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000056"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000057"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000058"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000059"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000060"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000061"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000062"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000063"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000064"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000065"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000066"));

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-1111-000000000067"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "event_registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 6, 18, 11, 54, 32, DateTimeKind.Utc).AddTicks(9973),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2026, 2, 6, 19, 5, 29, 415, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("040c1671-8008-4373-a8fc-271e6890eaef"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("2018318d-1806-4909-89a0-023157e66719"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3db7aba6-7d56-49b6-aa0f-94bfa983dfeb"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("3f2805ce-a319-43ee-89f6-ab4f9ce2400f"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("4c8ff2c7-12b3-4221-a90e-6ef5e1f28de5"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("53fbb707-3dc7-4723-ad48-957f58c35eaa"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("60031424-d223-4879-b28a-bedbc6145b3d"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("6cd3db2d-4bb6-4693-999c-d3a02298271e"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("a1eb8095-d5b8-49c4-89a2-95ef3539879c"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b4b8ee97-6874-4089-946f-ef03e030c265"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b71da4ec-f0e0-41c6-a051-06ec2de3ec3a"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("b91027c1-cccd-4963-b9cf-80c90962349e"),
                column: "major",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "alumni",
                keyColumn: "id",
                keyValue: new Guid("d889db9a-784d-40b5-8b9f-640431ad0970"),
                column: "major",
                value: "Management");

            migrationBuilder.InsertData(
                table: "role_navigation",
                columns: new[] { "id", "created_at", "navigation_item_id", "role_id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08e81a51-a147-4b46-9181-27e949a7373c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7935) },
                    { new Guid("0bed420b-4809-4b55-b3bc-ac93628d1fba"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(9004) },
                    { new Guid("0f186ed8-a0cf-4609-a7ce-1649cf8241fb"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000018"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(2247) },
                    { new Guid("1b585702-597b-4827-a7a6-690d61d853e2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000013"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1818) },
                    { new Guid("1c0ac468-9f80-4d0b-99dd-00fefe2bcdac"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7910) },
                    { new Guid("21229c46-8bf2-47d9-a1a9-c10efca8a238"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000019"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(2259) },
                    { new Guid("219b5043-69ca-4597-875f-f06c46ebd3a9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000016"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4672) },
                    { new Guid("2496e09e-c106-4fd1-90fb-e5dbb7c7b9d3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6420) },
                    { new Guid("2833fdeb-720f-47ab-b78c-8da222e80674"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(767) },
                    { new Guid("2afaea7e-cb71-4d44-9a49-1c48e3fa8013"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1716) },
                    { new Guid("31b122a8-ca69-4003-8455-011e6c2718af"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1704) },
                    { new Guid("327553ff-c005-4ab9-91d6-8159183f0ae6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6493) },
                    { new Guid("33a07776-f285-4cef-81b1-7c4bc6dfdd32"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000009"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1769) },
                    { new Guid("34ced13f-19c9-4f7c-bf1c-3b05b67869ca"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4535) },
                    { new Guid("36e641b4-d5fb-44fa-b5f3-4aeac6631320"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000006"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4547) },
                    { new Guid("3a7341f3-662e-448f-b2cc-f3b3cb116278"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000011"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4608) },
                    { new Guid("4a9fdde0-03bc-46f4-925d-9178041f284a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(8992) },
                    { new Guid("5288f959-5f67-49c0-ade4-4e53bbaaef0f"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7922) },
                    { new Guid("56284bd9-5873-4a17-80ad-72c6d79b91cb"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000013"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4633) },
                    { new Guid("586af558-1f83-4418-a4ad-f799ab110c68"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7959) },
                    { new Guid("5dfa6000-f2cc-400a-bd52-4f9ed3d9a312"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000011"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7970) },
                    { new Guid("5e7afe93-a935-4a20-acfa-e9af9c62c119"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6433) },
                    { new Guid("64b29d58-40d1-4187-b675-e55028630dec"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7898) },
                    { new Guid("6770ae19-94fd-4227-990a-8468f31b52ef"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1782) },
                    { new Guid("6afbc2ae-f514-46ef-b22e-0948370ae16c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000015"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4660) },
                    { new Guid("77bfa9d8-5465-48cb-b06e-0eac983064d5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6445) },
                    { new Guid("803a2bb8-f9b4-4e29-8052-8d9f465342ec"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000015"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(2193) },
                    { new Guid("85c83279-7edf-44be-b85e-1b492b27e825"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000009"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7947) },
                    { new Guid("8acf250e-369e-403d-b036-882955e0c872"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000016"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(2215) },
                    { new Guid("905871d7-091b-46a9-b958-4df80a8d7baa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6457) },
                    { new Guid("95d8d1d4-b169-4ff3-aaa8-f93f87416082"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1678) },
                    { new Guid("983d45df-8059-4385-b4d9-44c9a9581cb2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4486) },
                    { new Guid("a6ed02b0-1d2d-4732-adfb-36c35a1fa28d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000006"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1733) },
                    { new Guid("aaefc255-18ef-4c05-9d00-2041047028c6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000012"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(7982) },
                    { new Guid("ad478ac7-025b-4be4-98c0-fc4321e9299b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000011"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1794) },
                    { new Guid("b21799e5-f349-4e33-8023-acb1d985d54a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000012"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4621) },
                    { new Guid("b2a329dd-3995-44ea-ab18-93516815ee1c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000007"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4559) },
                    { new Guid("bdea9181-504a-49e8-bbfb-d56de461dd24"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000008"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6481) },
                    { new Guid("bf26e29d-77a5-4e9c-9039-316aa8cdc933"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(8980) },
                    { new Guid("ce02ac02-4f35-4e8c-a5a7-6cbc2cef191e"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000014"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1830) },
                    { new Guid("d300b455-911d-425f-b9da-9a071c3488e5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000010"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4594) },
                    { new Guid("dd5ecc7a-9352-441e-8c7c-fe9cac03b13c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000017"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(2227) },
                    { new Guid("de04d351-e542-49ff-850d-b173deaa2ca1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(8968) },
                    { new Guid("eaf4a1b0-a811-4198-9596-8f14dd623921"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000008"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1757) },
                    { new Guid("f006df8e-d243-4e77-adc2-2723f0678708"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4523) },
                    { new Guid("f153b7a8-e504-4482-90da-9db9d464f51d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1692) },
                    { new Guid("f2fe8790-c109-4f90-a5cc-f38c647b56c4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4500) },
                    { new Guid("f3cded1c-60b7-419d-ab0c-2d5764618744"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000007"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1745) },
                    { new Guid("f60e739e-e665-44b3-ac6d-f3055e67d404"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000009"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4582) },
                    { new Guid("f895aaea-b113-421d-8a21-963db5cdfe22"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000012"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(1806) },
                    { new Guid("f9fc7e51-8d89-43f5-8404-d15af692fe3a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000014"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4645) },
                    { new Guid("fb24aeee-fe97-4004-b17e-adf79c73dece"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000013"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6505) },
                    { new Guid("fe0f6a6c-b3bd-4a47-a698-db9627bdece6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000008"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4571) },
                    { new Guid("fe466335-336b-4efb-9d9a-535d53132d43"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(4511) },
                    { new Guid("fedab0a7-20e2-43ce-b82f-413bc9b94b56"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("90000000-0000-0000-0000-000000000007"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 64, DateTimeKind.Utc).AddTicks(6469) }
                });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "id", "created_at", "permission_id", "role_id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03a669f1-1c55-4727-bcb3-aca2d4329ea5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8172) },
                    { new Guid("0693a8e2-aecd-4d2f-8a18-37217567da69"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8158) },
                    { new Guid("121f012a-80c4-49b2-a751-ac3342973c2c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9751) },
                    { new Guid("14599bb6-02b6-45e4-a77f-7a99cdd1d44b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(5026) },
                    { new Guid("17adf084-d862-4899-94ad-731359fe0ecf"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9962) },
                    { new Guid("19da6304-a0f3-4e61-9aca-888233ac31ed"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(9118) },
                    { new Guid("1bff6fce-82fb-4576-8244-f5d126d96dd1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9897) },
                    { new Guid("1e0dc091-645b-460b-804f-1f0377d87010"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4887) },
                    { new Guid("27ae68c0-b7e5-49fe-93a7-27a0e3c53419"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(9135) },
                    { new Guid("2a699bf1-35ff-43d2-83d5-675e34b96111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4874) },
                    { new Guid("2c83aea9-8b1e-4f8c-9f09-a511a1cb4d57"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9819) },
                    { new Guid("2e8ced0c-14be-4c25-a72d-ea97e35d9fd1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(5039) },
                    { new Guid("2ec418bd-9191-4cba-a39f-5ececf3bf593"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9937) },
                    { new Guid("30108b3f-0874-428e-bf8c-84360e07869b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9833) },
                    { new Guid("33fcda4b-b4b1-488a-9fcd-a3278fb02671"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("70000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(39) },
                    { new Guid("3e82ff25-4518-4d01-a637-64376b574a70"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9794) },
                    { new Guid("3f69cd8f-58c3-46b4-8371-043cee81fcfd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4858) },
                    { new Guid("40d67713-ab22-490d-90eb-da2c90b4034c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc) },
                    { new Guid("47feda0e-cfd1-4987-9a12-51dbc1a4cf3e"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8233) },
                    { new Guid("4acef2d4-7735-4517-a7fc-4182aadbcbcc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9846) },
                    { new Guid("4db7525f-e545-4e54-9d51-4333dfcb7af3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6966) },
                    { new Guid("568528e3-1524-44c2-a6e1-c1f85b66fe31"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4683) },
                    { new Guid("58a822cf-4a52-46b2-92a5-cd1e6b8da9c7"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6894) },
                    { new Guid("63ed6117-2ca4-4b30-a189-7de2648b1dc8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4975) },
                    { new Guid("641d9c93-17da-47ec-b309-bb7599e3db10"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8220) },
                    { new Guid("65459e0f-5bc7-4dca-9f52-fc581b82ec38"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8257) },
                    { new Guid("68be4787-8e9c-4b4d-8ce7-b5b04c9d115e"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6954) },
                    { new Guid("6a5e6f5f-41bc-4df5-b837-71dcbe14da07"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(13) },
                    { new Guid("6b49241c-c8b2-4d73-a232-671940f562b9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4899) },
                    { new Guid("6d414036-35bf-4e29-ba8a-17b13305cd32"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9725) },
                    { new Guid("7201eff4-2480-4129-a993-114a6e4bc785"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9884) },
                    { new Guid("7240432e-fe87-426a-b721-ef3a2863b7fd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6942) },
                    { new Guid("740401e0-28b4-4a1b-8526-ddc36745d03c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9910) },
                    { new Guid("7550576d-755d-426e-9884-c0dfe6959d49"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4988) },
                    { new Guid("7d3e9415-6037-4674-85f5-b33fb02d7877"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9950) },
                    { new Guid("82889fe1-ebeb-413c-a1a2-9d598687c4b9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(9147) },
                    { new Guid("90d147e4-6270-4eb1-b653-a412b0f1c722"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9987) },
                    { new Guid("9156de16-6abd-4cfc-a521-a15012ff50a1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9781) },
                    { new Guid("952a5edb-eee2-4a5b-b41b-792d988502b8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9859) },
                    { new Guid("9667cbaa-aa79-4c61-b8fd-78ca5b73ebed"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4845) },
                    { new Guid("9753d04f-bef6-4e34-be28-6e287faec4ea"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6880) },
                    { new Guid("9e147443-25b9-4af6-9a09-6786b33bd0fc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9764) },
                    { new Guid("9e263daf-7944-4f07-b483-da2c0a56cde5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("70000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(52) },
                    { new Guid("a5a108bd-dff5-438c-a723-2c0b2d7b7170"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(26) },
                    { new Guid("ae971419-ad48-47b5-9c0b-8625aae122b9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6918) },
                    { new Guid("bb8f4a82-bb7f-41f2-9174-b3077e8fcbd4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9806) },
                    { new Guid("bdab3c5f-ebd8-44c9-b2b6-fb1438848d56"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9872) },
                    { new Guid("be47cdc8-5564-468f-8894-97e8ddeb2e53"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(8714) },
                    { new Guid("c20ed225-f040-4912-baed-e61876f6b20f"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4925) },
                    { new Guid("cbe6b346-0789-43b3-811c-d397fc69c886"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4938) },
                    { new Guid("cc40b330-8ab2-4e0c-9a09-822153eade01"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8208) },
                    { new Guid("cda4c9bd-e8d3-4815-8cd5-05d093e41351"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(5013) },
                    { new Guid("cf61b868-9113-4bd8-a1e8-d2d860229062"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000002"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6906) },
                    { new Guid("d927cc1e-3531-4857-baad-a91629b05ec5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(6930) },
                    { new Guid("e15b49b6-5b6f-4a05-bac9-db91c97f5601"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4950) },
                    { new Guid("e38e338d-2b9b-4f50-98fb-8d22b3ced05b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4912) },
                    { new Guid("e714fe81-422b-4994-a31b-3a4f886072ba"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8196) },
                    { new Guid("ea727c6f-dd48-4a1c-a0bd-ec1d56eac940"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("50000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9975) },
                    { new Guid("eacf0ee8-1516-4ca6-b4d9-6cfc5378d2f1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000001"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8184) },
                    { new Guid("eb76803d-1d5f-42a0-8217-bff236bb3faf"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(8245) },
                    { new Guid("ed713d7f-4fe2-44ef-bdb7-7293429aac0d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4712) },
                    { new Guid("f40c50ee-fb7b-47bf-8d27-3208a4078ee2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("30000000-0000-0000-0000-000000000005"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4963) },
                    { new Guid("f92686c0-1993-4dc7-98cd-87c2d908b74d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(5001) },
                    { new Guid("f94b2319-a0a9-4e79-83b2-afad1c846528"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4724) },
                    { new Guid("f9b2c970-3a31-4a29-8cfd-fd926d05ccee"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9738) },
                    { new Guid("fd81443b-bf55-4c74-b3a0-cdbe2aa106f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 6, 18, 11, 54, 62, DateTimeKind.Utc).AddTicks(9922) },
                    { new Guid("fdf10b47-befb-4a17-a0b3-637832e9ff65"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 6, 18, 11, 54, 63, DateTimeKind.Utc).AddTicks(4698) }
                });
        }
    }
}
