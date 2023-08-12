using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("71a84ba7-1f6c-468e-b334-862fb89ca31e"), "Hard" },
                    { new Guid("8072210a-403e-4f60-a006-5c0fee7d5ab0"), "Medium" },
                    { new Guid("c6324484-c5b4-49ae-8b5f-729bdd5ed166"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14876ed1-621b-429f-8863-66cae8baeb15"), "KTM", "Shivapuri", "https://en.wikipedia.org/wiki/Shivapuri_Nagarjun_National_Park#/media/File:A_view_of_Shivapuri_national_park_from_Sundarijal.jpg" },
                    { new Guid("2c2b2bf6-7611-4c2a-b6ad-63afb28c0fd4"), "TMGS", "Tamghas", "https://thegreathimalayas.files.wordpress.com/2015/04/resunga.jpg" },
                    { new Guid("a9755b67-f022-4dc3-ad0d-03d7955fa75b"), "BTL", "Butwal", "https://en.wikipedia.org/wiki/Butwal#/media/File:Butwal.jpg" },
                    { new Guid("de86cc6a-026e-491b-ad10-52b15d266a66"), "PKH", "Pokhara", "https://images.pexels.com/photos/6822183/pexels-photo-6822183.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("71a84ba7-1f6c-468e-b334-862fb89ca31e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8072210a-403e-4f60-a006-5c0fee7d5ab0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c6324484-c5b4-49ae-8b5f-729bdd5ed166"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14876ed1-621b-429f-8863-66cae8baeb15"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2c2b2bf6-7611-4c2a-b6ad-63afb28c0fd4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a9755b67-f022-4dc3-ad0d-03d7955fa75b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("de86cc6a-026e-491b-ad10-52b15d266a66"));
        }
    }
}
