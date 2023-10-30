using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_api_seminarski_proba.Migrations
{
    /// <inheritdoc />
    public partial class dodanBrojKlikova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojKlikova",
                table: "Proizvod",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojKlikova",
                table: "Proizvod");
        }
    }
}
