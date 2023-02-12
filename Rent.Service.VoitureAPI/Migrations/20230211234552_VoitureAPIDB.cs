using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent.Service.VoitureAPI.Migrations
{
    public partial class VoitureAPIDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Voitures",
                columns: new[] { "VoitureId", "CategoryName", "ImageURL", "PriceByDay", "marque" },
                values: new object[,]
                {
                    { 1, "Citadine", "https://artisanaka.blob.core.windows.net/artisana/v3.png", 540.0, "Peugeot 208" },
                    { 2, "Citadine", "https://artisanaka.blob.core.windows.net/artisana/v2.png", 400.0, "Dacia Sandero" },
                    { 3, "Citadine", "https://artisanaka.blob.core.windows.net/artisana/v1.png", 650.0, "Renault Clio 4" },
                    { 4, "Citadine", "https://artisanaka.blob.core.windows.net/artisana/v4.png", 450.0, "Citroën C3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Voitures",
                keyColumn: "VoitureId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voitures",
                keyColumn: "VoitureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Voitures",
                keyColumn: "VoitureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Voitures",
                keyColumn: "VoitureId",
                keyValue: 4);
        }
    }
}
