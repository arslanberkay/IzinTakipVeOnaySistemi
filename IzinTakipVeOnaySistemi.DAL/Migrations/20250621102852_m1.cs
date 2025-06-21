using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzinTakipVeOnaySistemi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdemeBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdenecekTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeBilgileri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpostaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IzinSayisi = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    AktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzinTalepler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanId = table.Column<int>(type: "int", nullable: false),
                    TalepDurumu = table.Column<int>(type: "int", nullable: false),
                    OnayTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OdemeBilgisiId = table.Column<int>(type: "int", nullable: false),
                    AktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinTalepler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IzinTalepler_Calisanlar_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinTalepler_OdemeBilgileri_OdemeBilgisiId",
                        column: x => x.OdemeBilgisiId,
                        principalTable: "OdemeBilgileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_DepartmanId",
                table: "Calisanlar",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_IzinTalepler_CalisanId",
                table: "IzinTalepler",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_IzinTalepler_OdemeBilgisiId",
                table: "IzinTalepler",
                column: "OdemeBilgisiId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinTalepler");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "OdemeBilgileri");

            migrationBuilder.DropTable(
                name: "Departmanlar");
        }
    }
}
