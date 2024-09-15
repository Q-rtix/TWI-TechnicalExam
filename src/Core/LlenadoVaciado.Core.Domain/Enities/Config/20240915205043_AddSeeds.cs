using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreewInc.Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Adriana.Rolfson@yahoo.com", "Amira Crooks", "Pass1234", "1 7691651548" },
                    { 2, "Telly_Renner40@hotmail.com", "Maeve Jovanny Trantow", "Pass1234", "1 7691651548" },
                    { 3, "Magdalena_Ullrich@yahoo.com", "Dina Dooley", "Pass1234", "1 7691651548" },
                    { 4, "Torrey_Powlowski90@gmail.com", "Issac Bailey", "Pass1234", "1 7691651548" },
                    { 5, "Lyla55@gmail.com", "Kasey Price", "Pass1234", "1 7691651548" },
                    { 6, "Millie14@gmail.com", "Alisha Schroeder", "Pass1234", "1 7691651548" },
                    { 7, "Tyshawn86@gmail.com", "Delbert Schaefer", "Pass1234", "1 7691651548" },
                    { 8, "Emmalee_Feil@gmail.com", "Helene Ephraim Turner", "Pass1234", "1 7691651548" },
                    { 9, "Bryon.Muller@gmail.com", "Merlin Heath Beahan", "Pass1234", "1 7691651548" },
                    { 10, "Jaime_Streich21@gmail.com", "Jesse Ullrich", "Pass1234", "1 7691651548" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Unde sapiente veniam vero delectus ex.", "Fantastic Fresh Chips", 285.28m, 4 },
                    { 2, "Facilis voluptatem ipsum quasi facere.", "Tasty Frozen Tuna", 537.14m, 18 },
                    { 3, "Quia vitae dolor rerum aut qui ullam ut fugit.", "Sleek Concrete Gloves", 261.35m, 66 },
                    { 4, "Illo adipisci eos facere placeat.", "Sleek Steel Gloves", 867.74m, 78 },
                    { 5, "Ipsum iusto aut suscipit autem voluptatem et nemo.", "Awesome Metal Gloves", 271.70m, 86 },
                    { 6, "Occaecati aut earum ratione qui.", "Awesome Concrete Chicken", 909.99m, 83 },
                    { 7, "Omnis recusandae aliquam quasi voluptate minima eveniet.", "Generic Soft Mouse", 546.26m, 27 },
                    { 8, "Modi vitae illo inventore iste.", "Refined Cotton Chicken", 310.49m, 25 },
                    { 9, "Tempora voluptate repudiandae.", "Generic Fresh Bike", 491.21m, 26 },
                    { 10, "Molestiae ea sit.", "Awesome Granite Pants", 651.94m, 93 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
