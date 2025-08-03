using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class KitapStokEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StokMiktari",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StokMiktari",
                table: "Kitaplar");
        }
    }
}
