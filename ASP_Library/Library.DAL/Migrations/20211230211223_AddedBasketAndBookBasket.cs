using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class AddedBasketAndBookBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sent = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    NoCopies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBaskets_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBaskets_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AdressId",
                table: "Baskets",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBaskets_BasketId",
                table: "BookBaskets",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBaskets_BookId",
                table: "BookBaskets",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBaskets");

            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
