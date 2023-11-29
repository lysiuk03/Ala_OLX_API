using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Help" },
                    { 2, "Children's world" },
                    { 3, "Real estate" },
                    { 4, "Car" },
                    { 5, "Spare parts" },
                    { 6, "Work" },
                    { 7, "Animals" },
                    { 8, "House and garden" },
                    { 9, "Electronics" },
                    { 10, "Business and services" },
                    { 11, "Rent and hire" },
                    { 12, "Fashion and style" },
                    { 13, "Hobbies, recreation and sports" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vinnitsa" },
                    { 2, "Dnipro" },
                    { 3, "Donetsk" },
                    { 4, "Zhytomyr" },
                    { 5, "Zaporizhzhia" },
                    { 6, "Ivano-Frankivsk" },
                    { 7, "Kyiv" },
                    { 8, "Kropyvnytskyi" },
                    { 9, "Luhansk" },
                    { 10, "Lutsk" },
                    { 11, "Lviv" },
                    { 12, "Mykolaiv" },
                    { 13, "Odesa" },
                    { 14, "Poltava" },
                    { 15, "Rivne" },
                    { 16, "Sumy" },
                    { 17, "Ternopil" },
                    { 18, "Uzhhorod" },
                    { 19, "Kharkiv" },
                    { 20, "Kherson" },
                    { 21, "Khmelnytskyi" },
                    { 22, "Cherkasy" },
                    { 23, "Chernivtsi" },
                    { 24, "Chernihiv" }
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "CategoryId", "ContactName", "Description", "Discount", "ImageURL", "InStock", "Name", "Phone", "Price", "RegionId" },
                values: new object[,]
                {
                    { 1, 7, "Dasha", null, null, "https://i.pinimg.com/736x/63/ec/9b/63ec9b2eeb79eb6cbaf9d05c47a19a4c.jpg", true, "Dog", "+380674973625", 100m, 1 },
                    { 2, 7, "Masha", null, null, "https://static.fundacion-affinity.org/cdn/farfuture/xFsdVk-9Vi8ifllknxGrwV-ul0WVSmjXl7DSObD4iLU/mtime:1644939075/sites/default/files/los-10-sonidos-principales-del-gato-fa.jpg", true, "Cat", "+380854763746", 80m, 2 },
                    { 3, 9, "Roma", null, null, "https://www.cnet.com/a/img/resize/0302d07e10ba8dc211f7b4e25891ad46dda31976/hub/2023/02/05/f52fdc98-dafc-4d05-b20e-8bd936b49a53/oneplus-11-review-cnet-lanxon-promo-8.jpg", true, "Phone", "+380857497463", 200m, 3 },
                    { 4, 4, "Misha", null, null, "https://cdn.jdpower.com/Average%20Weight%20Of%20A%20Car.jpg", true, "Car", "+380654788473", 3000m, 4 },
                    { 5, 12, "Elia", null, null, "https://images.prom.ua/4137447034_w640_h640_muzhskoj-zimnij-svitshot.jpg", true, "Nike", "+380758497362", 250m, 5 },
                    { 6, 12, "Boria", null, null, "https://vintagewholesaleeurope.com/cdn/shop/products/image_8e7df972-8464-40bd-89b6-72b19fa2519b_1024x1024@2x.jpg", true, "Carhartt", "+380584763847", 300m, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CategoryId",
                table: "Announcements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_RegionId",
                table: "Announcements",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
