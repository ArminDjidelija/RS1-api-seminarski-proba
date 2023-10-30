using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_api_seminarski_proba.Migrations
{
    /// <inheritdoc />
    public partial class GlavnaObicnaPotkategorija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategorijaGlavnaKategorija");

            migrationBuilder.DropTable(
                name: "KategorijaPotkategorija");

            migrationBuilder.RenameColumn(
                name: "Kolicina",
                table: "Proizvod",
                newName: "PocetnaKolicina");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Proizvod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KategorijaID",
                table: "Potkategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GlavnaKategorijaID",
                table: "Kategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Potkategorija_KategorijaID",
                table: "Potkategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorija_GlavnaKategorijaID",
                table: "Kategorija",
                column: "GlavnaKategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorija_GlavnaKategorija_GlavnaKategorijaID",
                table: "Kategorija",
                column: "GlavnaKategorijaID",
                principalTable: "GlavnaKategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Potkategorija_Kategorija_KategorijaID",
                table: "Potkategorija",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorija_GlavnaKategorija_GlavnaKategorijaID",
                table: "Kategorija");

            migrationBuilder.DropForeignKey(
                name: "FK_Potkategorija_Kategorija_KategorijaID",
                table: "Potkategorija");

            migrationBuilder.DropIndex(
                name: "IX_Potkategorija_KategorijaID",
                table: "Potkategorija");

            migrationBuilder.DropIndex(
                name: "IX_Kategorija_GlavnaKategorijaID",
                table: "Kategorija");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "KategorijaID",
                table: "Potkategorija");

            migrationBuilder.DropColumn(
                name: "GlavnaKategorijaID",
                table: "Kategorija");

            migrationBuilder.RenameColumn(
                name: "PocetnaKolicina",
                table: "Proizvod",
                newName: "Kolicina");

            migrationBuilder.CreateTable(
                name: "KategorijaGlavnaKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlavnaKategorijaID = table.Column<int>(type: "int", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaGlavnaKategorija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategorijaGlavnaKategorija_GlavnaKategorija_GlavnaKategorijaID",
                        column: x => x.GlavnaKategorijaID,
                        principalTable: "GlavnaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategorijaGlavnaKategorija_GlavnaKategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "GlavnaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KategorijaPotkategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    PotkategorijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaPotkategorija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategorijaPotkategorija_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategorijaPotkategorija_Potkategorija_PotkategorijaID",
                        column: x => x.PotkategorijaID,
                        principalTable: "Potkategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaGlavnaKategorija_GlavnaKategorijaID",
                table: "KategorijaGlavnaKategorija",
                column: "GlavnaKategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaGlavnaKategorija_KategorijaID",
                table: "KategorijaGlavnaKategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaPotkategorija_KategorijaID",
                table: "KategorijaPotkategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaPotkategorija_PotkategorijaID",
                table: "KategorijaPotkategorija",
                column: "PotkategorijaID");
        }
    }
}
