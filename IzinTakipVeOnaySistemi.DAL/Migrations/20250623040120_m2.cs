using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzinTakipVeOnaySistemi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzinTalepler_OdemeBilgileri_OdemeBilgisiId",
                table: "IzinTalepler");

            migrationBuilder.DropIndex(
                name: "IX_IzinTalepler_OdemeBilgisiId",
                table: "IzinTalepler");

            migrationBuilder.DropColumn(
                name: "OdemeBilgisiId",
                table: "IzinTalepler");

            migrationBuilder.AddColumn<int>(
                name: "IzinTalepId",
                table: "OdemeBilgileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OdemeBilgileri_IzinTalepId",
                table: "OdemeBilgileri",
                column: "IzinTalepId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OdemeBilgileri_IzinTalepler_IzinTalepId",
                table: "OdemeBilgileri",
                column: "IzinTalepId",
                principalTable: "IzinTalepler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdemeBilgileri_IzinTalepler_IzinTalepId",
                table: "OdemeBilgileri");

            migrationBuilder.DropIndex(
                name: "IX_OdemeBilgileri_IzinTalepId",
                table: "OdemeBilgileri");

            migrationBuilder.DropColumn(
                name: "IzinTalepId",
                table: "OdemeBilgileri");

            migrationBuilder.AddColumn<int>(
                name: "OdemeBilgisiId",
                table: "IzinTalepler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IzinTalepler_OdemeBilgisiId",
                table: "IzinTalepler",
                column: "OdemeBilgisiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IzinTalepler_OdemeBilgileri_OdemeBilgisiId",
                table: "IzinTalepler",
                column: "OdemeBilgisiId",
                principalTable: "OdemeBilgileri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
