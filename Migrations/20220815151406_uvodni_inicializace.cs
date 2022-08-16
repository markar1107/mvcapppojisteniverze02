using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcapppojisteniverze02.Migrations
{
    public partial class uvodni_inicializace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulice = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Psc = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    ProduktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazev = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.ProduktID);
                });

            migrationBuilder.CreateTable(
                name: "ZaznamyPojisteni",
                columns: table => new
                {
                    ZaznamPojisteniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    PredmetPojisteni = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    ZacatekPojisteni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KonecPojisteni = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaznamyPojisteni", x => x.ZaznamPojisteniID);
                    table.ForeignKey(
                        name: "FK_ZaznamyPojisteni_Klienti_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZaznamyPojisteni_Produkty_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkty",
                        principalColumn: "ProduktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZaznamyPojisteni_KlientID",
                table: "ZaznamyPojisteni",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_ZaznamyPojisteni_ProduktID",
                table: "ZaznamyPojisteni",
                column: "ProduktID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZaznamyPojisteni");

            migrationBuilder.DropTable(
                name: "Klienti");

            migrationBuilder.DropTable(
                name: "Produkty");
        }
    }
}
