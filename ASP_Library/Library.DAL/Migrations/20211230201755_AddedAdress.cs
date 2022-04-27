using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class AddedAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    NoApartment = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
