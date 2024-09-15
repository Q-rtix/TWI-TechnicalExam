using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreewInc.Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Allen.Langosh@hotmail.com", "Kale Lebsack" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Virgie_Bashirian@hotmail.com", "Finn Jamel Nitzsche" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Eliane15@gmail.com", "Brandyn Hudson" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Bethel.Grady48@hotmail.com", "Melissa Lila Jacobs" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Electa_Wunsch97@hotmail.com", "Art Bayer" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Pasquale13@hotmail.com", "Jaylon Esther Cole" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Dayne80@hotmail.com", "Stephon Karli Herman" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Caesar.Schiller@hotmail.com", "Sydnie Alyce Flatley" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Dillon_Erdman20@hotmail.com", "Jensen Dare" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Maria.Denesik74@gmail.com", "Elouise Borer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Non consequatur perferendis doloribus sed unde.", "Ergonomic Wooden Salad", 51.83m, 55 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Qui quis debitis fugiat qui quia sit aspernatur.", "Tasty Rubber Mouse", 185.71m, 87 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Praesentium iste quibusdam iusto eveniet recusandae minima minus esse.", "Awesome Metal Cheese", 16.14m, 56 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Et dolor voluptatibus ullam ad perspiciatis.", "Incredible Plastic Salad", 797.87m, 72 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Voluptatibus quam vel aperiam.", "Ergonomic Plastic Chips", 370.29m, 53 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Earum aspernatur ut dolore vel perferendis magni ex.", "Fantastic Plastic Tuna", 871.11m, 92 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Et nihil vel qui.", "Handcrafted Soft Mouse", 129.62m, 19 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Soluta nesciunt eaque placeat sed esse dolore.", "Awesome Frozen Ball", 258.73m, 31 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Debitis necessitatibus quos modi distinctio rerum iure qui.", "Fantastic Granite Sausages", 140.53m, 98 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Consequatur aliquid est.", "Refined Wooden Towels", 387.16m, 74 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Adriana.Rolfson@yahoo.com", "Amira Crooks" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Telly_Renner40@hotmail.com", "Maeve Jovanny Trantow" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Magdalena_Ullrich@yahoo.com", "Dina Dooley" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Torrey_Powlowski90@gmail.com", "Issac Bailey" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Lyla55@gmail.com", "Kasey Price" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Millie14@gmail.com", "Alisha Schroeder" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Tyshawn86@gmail.com", "Delbert Schaefer" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Emmalee_Feil@gmail.com", "Helene Ephraim Turner" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Bryon.Muller@gmail.com", "Merlin Heath Beahan" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "Jaime_Streich21@gmail.com", "Jesse Ullrich" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Unde sapiente veniam vero delectus ex.", "Fantastic Fresh Chips", 285.28m, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Facilis voluptatem ipsum quasi facere.", "Tasty Frozen Tuna", 537.14m, 18 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Quia vitae dolor rerum aut qui ullam ut fugit.", "Sleek Concrete Gloves", 261.35m, 66 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Illo adipisci eos facere placeat.", "Sleek Steel Gloves", 867.74m, 78 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Ipsum iusto aut suscipit autem voluptatem et nemo.", "Awesome Metal Gloves", 271.70m, 86 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Occaecati aut earum ratione qui.", "Awesome Concrete Chicken", 909.99m, 83 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Omnis recusandae aliquam quasi voluptate minima eveniet.", "Generic Soft Mouse", 546.26m, 27 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Modi vitae illo inventore iste.", "Refined Cotton Chicken", 310.49m, 25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Tempora voluptate repudiandae.", "Generic Fresh Bike", 491.21m, 26 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Molestiae ea sit.", "Awesome Granite Pants", 651.94m, 93 });
        }
    }
}
