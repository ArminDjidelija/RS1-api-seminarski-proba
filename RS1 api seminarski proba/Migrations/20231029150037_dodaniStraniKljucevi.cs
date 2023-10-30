using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_api_seminarski_proba.Migrations
{
    /// <inheritdoc />
    public partial class dodaniStraniKljucevi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProizvodKategorija",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PotkategorijaID",
                table: "ProizvodPotkategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProizvodID",
                table: "ProizvodPotkategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategorijaID",
                table: "ProizvodKategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProizvodID",
                table: "ProizvodKategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrendID",
                table: "Proizvod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodPotkategorija_PotkategorijaID",
                table: "ProizvodPotkategorija",
                column: "PotkategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodPotkategorija_ProizvodID",
                table: "ProizvodPotkategorija",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodKategorija_KategorijaID",
                table: "ProizvodKategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodKategorija_ProizvodID",
                table: "ProizvodKategorija",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_BrendID",
                table: "Proizvod",
                column: "BrendID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Brend_BrendID",
                table: "Proizvod",
                column: "BrendID",
                principalTable: "Brend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodKategorija_Kategorija_KategorijaID",
                table: "ProizvodKategorija",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodKategorija_Proizvod_ProizvodID",
                table: "ProizvodKategorija",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodPotkategorija_Potkategorija_PotkategorijaID",
                table: "ProizvodPotkategorija",
                column: "PotkategorijaID",
                principalTable: "Potkategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodPotkategorija_Proizvod_ProizvodID",
                table: "ProizvodPotkategorija",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Brend_BrendID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodKategorija_Kategorija_KategorijaID",
                table: "ProizvodKategorija");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodKategorija_Proizvod_ProizvodID",
                table: "ProizvodKategorija");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodPotkategorija_Potkategorija_PotkategorijaID",
                table: "ProizvodPotkategorija");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodPotkategorija_Proizvod_ProizvodID",
                table: "ProizvodPotkategorija");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodPotkategorija_PotkategorijaID",
                table: "ProizvodPotkategorija");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodPotkategorija_ProizvodID",
                table: "ProizvodPotkategorija");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodKategorija_KategorijaID",
                table: "ProizvodKategorija");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodKategorija_ProizvodID",
                table: "ProizvodKategorija");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_BrendID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "PotkategorijaID",
                table: "ProizvodPotkategorija");

            migrationBuilder.DropColumn(
                name: "ProizvodID",
                table: "ProizvodPotkategorija");

            migrationBuilder.DropColumn(
                name: "KategorijaID",
                table: "ProizvodKategorija");

            migrationBuilder.DropColumn(
                name: "ProizvodID",
                table: "ProizvodKategorija");

            migrationBuilder.DropColumn(
                name: "BrendID",
                table: "Proizvod");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProizvodKategorija",
                newName: "id");
        }
    }
}
