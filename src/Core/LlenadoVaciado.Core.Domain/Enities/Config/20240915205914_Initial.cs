using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreewInc.Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ken87@hotmail.com", "Ali Boyer", "Pass1234", "1 7691651548" },
                    { 2, "Desmond.Von@hotmail.com", "Hallie Alvera Wiegand", "Pass1234", "1 7691651548" },
                    { 3, "Madaline.Torphy91@gmail.com", "Raina Jalen Nader", "Pass1234", "1 7691651548" },
                    { 4, "Edyth.Witting88@gmail.com", "Hailee Breitenberg", "Pass1234", "1 7691651548" },
                    { 5, "Hattie12@yahoo.com", "Lori Mark O'Hara", "Pass1234", "1 7691651548" },
                    { 6, "Myron_Schaden44@gmail.com", "Deontae Glover", "Pass1234", "1 7691651548" },
                    { 7, "Lempi_Raynor@yahoo.com", "Dallas Mina Stracke", "Pass1234", "1 7691651548" },
                    { 8, "Zola56@hotmail.com", "Leonel Bradtke", "Pass1234", "1 7691651548" },
                    { 9, "Florencio.Witting44@yahoo.com", "Cecile Terrance White", "Pass1234", "1 7691651548" },
                    { 10, "Geovanni.Murray@yahoo.com", "Laverne Garrison Farrell", "Pass1234", "1 7691651548" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Totam voluptatem quas asperiores cupiditate qui qui.", "Small Steel Pizza", 132.54m, 53 },
                    { 2, "Magni et consequatur.", "Refined Frozen Table", 593.21m, 27 },
                    { 3, "Repellendus consectetur odio tempora nihil quis excepturi dolores.", "Tasty Plastic Soap", 295.20m, 5 },
                    { 4, "Non consequuntur dolores et incidunt qui.", "Practical Granite Computer", 856.40m, 96 },
                    { 5, "Nemo id ad assumenda sapiente qui perspiciatis odit esse adipisci.", "Tasty Rubber Fish", 978.62m, 47 },
                    { 6, "Rerum nobis et accusamus necessitatibus a beatae hic ipsum.", "Handcrafted Frozen Shirt", 592.42m, 62 },
                    { 7, "Nostrum omnis dolorem quia sit beatae nihil et.", "Licensed Concrete Cheese", 203.41m, 61 },
                    { 8, "Qui non culpa est qui placeat et esse.", "Handcrafted Metal Bacon", 103.07m, 39 },
                    { 9, "Beatae sit aut dolor iusto quia perspiciatis.", "Handmade Fresh Bike", 910.44m, 57 },
                    { 10, "Qui repudiandae odit cupiditate facilis et odio odit.", "Small Metal Pants", 820.03m, 78 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
