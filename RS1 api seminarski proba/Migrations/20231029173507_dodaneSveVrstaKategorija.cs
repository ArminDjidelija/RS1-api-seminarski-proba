using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_api_seminarski_proba.Migrations
{
    /// <inheritdoc />
    public partial class dodaneSveVrstaKategorija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodKategorija");

            migrationBuilder.DropTable(
                name: "ProizvodPotkategorija");

            migrationBuilder.AddColumn<int>(
                name: "PotkategorijaID",
                table: "Proizvod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GlavnaKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlavnaKategorija", x => x.Id);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KategorijaPotkategorija_Potkategorija_PotkategorijaID",
                        column: x => x.PotkategorijaID,
                        principalTable: "Potkategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KategorijaGlavnaKategorija_GlavnaKategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "GlavnaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_PotkategorijaID",
                table: "Proizvod",
                column: "PotkategorijaID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Potkategorija_PotkategorijaID",
                table: "Proizvod",
                column: "PotkategorijaID",
                principalTable: "Potkategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Potkategorija_PotkategorijaID",
                table: "Proizvod");

            migrationBuilder.DropTable(
                name: "KategorijaGlavnaKategorija");

            migrationBuilder.DropTable(
                name: "KategorijaPotkategorija");

            migrationBuilder.DropTable(
                name: "GlavnaKategorija");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_PotkategorijaID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "PotkategorijaID",
                table: "Proizvod");

            migrationBuilder.CreateTable(
                name: "ProizvodKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodKategorija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProizvodKategorija_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProizvodKategorija_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodPotkategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotkategorijaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodPotkategorija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProizvodPotkategorija_Potkategorija_PotkategorijaID",
                        column: x => x.PotkategorijaID,
                        principalTable: "Potkategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProizvodPotkategorija_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodKategorija_KategorijaID",
                table: "ProizvodKategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodKategorija_ProizvodID",
                table: "ProizvodKategorija",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodPotkategorija_PotkategorijaID",
                table: "ProizvodPotkategorija",
                column: "PotkategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodPotkategorija_ProizvodID",
                table: "ProizvodPotkategorija",
                column: "ProizvodID");
        }
    }
}
