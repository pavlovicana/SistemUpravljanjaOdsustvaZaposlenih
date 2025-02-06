using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f56cfd75-8375-43da-9ae0-0fa940a097f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3414e41-0466-4846-ade7-7233028e77d5", "AQAAAAIAAYagAAAAEFNQAmp83JqPBDYAENB7Hjfg5dp/vUoWjlavusSSoQNPJEtW0csQVIH6311YI4xDXQ==", "dde46158-7534-46f4-998c-0e93a9f12beb" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DatumRodjenja", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "083effaf-d3b2-42e7-8985-3e2ead23a99e", 0, "1498811d-1b35-4923-a228-edf8f03dd9b1", new DateOnly(1950, 12, 1), "administrator@localhost.com", true, "Default", false, null, "ADMINISTRATOR@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAEIXncAvWTvtMlZpvMM8od0iGyv/BUtSayJ8ssrP8MDrmAtYQ1f6+1CDcd1JJ5w4a6A==", null, false, "Administrator", "5d0165fb-b538-43b1-9a68-54f0b7ede030", false, "administrator@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9c451184-c8d7-4384-9c6d-396c615546ad", "083effaf-d3b2-42e7-8985-3e2ead23a99e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c451184-c8d7-4384-9c6d-396c615546ad", "083effaf-d3b2-42e7-8985-3e2ead23a99e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "083effaf-d3b2-42e7-8985-3e2ead23a99e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f56cfd75-8375-43da-9ae0-0fa940a097f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5debca13-6941-4e99-92f0-2594272cf4b8", "AQAAAAIAAYagAAAAEEW56TViylvAj57bojlNzZpO7El2sv9zUp0L/gtCc0jCIwA0dMNOgGne9VhL0LtVLQ==", "05ccbdab-e929-4a60-ab7a-a3fe1e669a00" });
        }
    }
}
