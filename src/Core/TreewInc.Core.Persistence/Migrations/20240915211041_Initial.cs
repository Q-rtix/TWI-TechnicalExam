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
                    Password = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false)
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
                    { 1, "Marco45@gmail.com", "Nettie Streich", "$2a$11$QcYNwvXh8Aq5cgs48kX/nOS9BkUbkZJ.eV6kA1bNeEr.ASEZudmOi", "1 7691651548" },
                    { 2, "Keenan.Casper95@hotmail.com", "Mylene Blanche Beatty", "$2a$11$zsVPE4dtzSuBJ8MwfwXesemIIEYkMZ4nZPD9HoDYhDgyW5sKegKYW", "1 7691651548" },
                    { 3, "Dangelo.Altenwerth36@yahoo.com", "Katlyn Considine", "$2a$11$Z00KYCOM83BxgWZ/4bKPceb6.rAF/Pzq4uCQw6OF9N2rGZG1SJozW", "1 7691651548" },
                    { 4, "Doug_Mills@gmail.com", "Katarina Derick Rosenbaum", "$2a$11$kVQM6wZOf/HadquvxcXVq.gLkSnwW0h.5lXIWeu1VYSQ58/Si/KFe", "1 7691651548" },
                    { 5, "Laron_Hammes@gmail.com", "Gus Pasquale Senger", "$2a$11$ESrcWEnW3KRw4z7/PZGixufzVRL30bf.lI2BEel9FyLl5QzD6keGW", "1 7691651548" },
                    { 6, "Eda_Haley@yahoo.com", "Asia Considine", "$2a$11$SzWIdYmDVrHqCAqiWofSK.Yh5dmsZiggglAP10NhirxjvoVsa/A2m", "1 7691651548" },
                    { 7, "Keenan34@gmail.com", "Lauretta Lowell Jerde", "$2a$11$gPkoSSpB1lpD6poCmca30O9HkuQO./2akYGTPbXkWwXewlOtGRKx.", "1 7691651548" },
                    { 8, "Leta.Runolfsdottir@hotmail.com", "Zelma Adell Marks", "$2a$11$iwpg2uC8gh4IpvR7Jz56x.fjMJq7eVh7U45rVFX7r.flB//neNWfm", "1 7691651548" },
                    { 9, "Willa42@yahoo.com", "Graciela Zane Howell", "$2a$11$mX5XthMdcx7Zi0eSkrgrPObsUutJ6OT7ZuuYsSR1it07PMb26p.q2", "1 7691651548" },
                    { 10, "Leda.Jenkins@hotmail.com", "Damon Tromp", "$2a$11$mCluNsKgXtGZkRJ6GL/2RezdU1/25VWft.r94qeA.qLV3NG.2xSMS", "1 7691651548" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Ducimus aperiam et dolores ut.", "Handcrafted Metal Mouse", 454.41m, 41 },
                    { 2, "Voluptatem soluta sapiente sit et est eius velit ea.", "Generic Cotton Pizza", 105.89m, 14 },
                    { 3, "Sed laboriosam quia enim hic recusandae saepe consequatur natus.", "Unbranded Steel Bacon", 645.18m, 50 },
                    { 4, "Voluptas quia harum fugit.", "Handmade Rubber Chair", 570.37m, 30 },
                    { 5, "Ipsa voluptas rerum voluptas facere officiis beatae esse voluptates iusto.", "Tasty Plastic Tuna", 977.19m, 41 },
                    { 6, "Labore voluptatem ab.", "Licensed Granite Table", 576.20m, 22 },
                    { 7, "Necessitatibus beatae magnam fuga.", "Incredible Plastic Chips", 852.78m, 40 },
                    { 8, "Earum delectus est dolores.", "Generic Granite Table", 731.81m, 85 },
                    { 9, "Ad laborum eum veritatis.", "Rustic Plastic Towels", 905.61m, 33 },
                    { 10, "Porro architecto occaecati consequatur et facere.", "Tasty Cotton Table", 686.78m, 67 }
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
