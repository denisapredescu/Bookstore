using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class NullFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInfo_Author_AuthorId",
                table: "AuthorInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Adresses_AdressId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInfo_AuthorId",
                table: "AuthorInfo");

            migrationBuilder.AlterColumn<int>(
                name: "AdressId",
                table: "Baskets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "AuthorInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInfo_AuthorId",
                table: "AuthorInfo",
                column: "AuthorId",
                unique: true,
                filter: "[AuthorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInfo_Author_AuthorId",
                table: "AuthorInfo",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Adresses_AdressId",
                table: "Baskets",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInfo_Author_AuthorId",
                table: "AuthorInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Adresses_AdressId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInfo_AuthorId",
                table: "AuthorInfo");

            migrationBuilder.AlterColumn<int>(
                name: "AdressId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "AuthorInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInfo_AuthorId",
                table: "AuthorInfo",
                column: "AuthorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInfo_Author_AuthorId",
                table: "AuthorInfo",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Adresses_AdressId",
                table: "Baskets",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
