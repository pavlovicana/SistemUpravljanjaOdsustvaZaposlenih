using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodavanjeTabeleTipOdsustva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipOdsustva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    BrojDana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipOdsustva", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipOdsustva");
        }
    }
}
