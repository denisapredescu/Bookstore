using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class WithoutAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Adresses_AdressId",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_AdressId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Baskets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileNumber = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    NoApartment = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AdressId",
                table: "Baskets",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Adresses_AdressId",
                table: "Baskets",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
