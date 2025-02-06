using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Migrations
{
    /// <inheritdoc />
    public partial class Reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f56cfd75-8375-43da-9ae0-0fa940a097f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5debca13-6941-4e99-92f0-2594272cf4b8", "AQAAAAIAAYagAAAAEEW56TViylvAj57bojlNzZpO7El2sv9zUp0L/gtCc0jCIwA0dMNOgGne9VhL0LtVLQ==", "05ccbdab-e929-4a60-ab7a-a3fe1e669a00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f56cfd75-8375-43da-9ae0-0fa940a097f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4f482cc-b71d-412e-aaa0-294e8c11be63", "AQAAAAIAAYagAAAAEI5/7ENlPUSct2YdL3Cvi6OQLqQDfkletTHXfFYeFeBc6hCAEtVYYofSg+ysN2Z0nw==", "a311dc39-fdf8-429e-9439-821d321f14d8" });
        }
    }
}
