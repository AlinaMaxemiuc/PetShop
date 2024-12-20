using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exp.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "Animale",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    gen = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    specie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    varsta = table.Column<int>(type: "int", nullable: true),
                    Greutate = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Animale__3213E83FBCC0A72B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    numar_comenzi = table.Column<int>(type: "int", nullable: true),
                    procent_discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3213E83F875390B0", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hrana",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nume = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descriere = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pret = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    stoc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hrana__3213E83F9A6F6F52", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nume = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    prenume = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    parola = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Utilizat__3213E83F5FD05E0A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_utilizator = table.Column<int>(type: "int", nullable: true),
                    id_hrana = table.Column<int>(type: "int", nullable: true),
                    frecventa = table.Column<int>(type: "int", nullable: true),
                    data_incepere = table.Column<DateOnly>(type: "date", nullable: true),
                    data_sfarsit = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Abonamen__3213E83F884FF988", x => x.id);
                    table.ForeignKey(
                        name: "FK__Abonament__id_hr__2D27B809",
                        column: x => x.id_hrana,
                        principalTable: "Hrana",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Abonament__id_ut__2C3393D0",
                        column: x => x.id_utilizator,
                        principalTable: "Utilizator",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_utilizator = table.Column<int>(type: "int", nullable: true),
                    id_abonament = table.Column<int>(type: "int", nullable: true),
                    data_comenzii = table.Column<DateOnly>(type: "date", nullable: true),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    discount = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comanda__3213E83F93CD6B16", x => x.id);
                    table.ForeignKey(
                        name: "FK__Comanda__id_abon__30F848ED",
                        column: x => x.id_abonament,
                        principalTable: "Abonament",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Comanda__id_util__300424B4",
                        column: x => x.id_utilizator,
                        principalTable: "Utilizator",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Livrari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_comanda = table.Column<int>(type: "int", nullable: true),
                    data_livrare = table.Column<DateOnly>(type: "date", nullable: true),
                    adresa_livrare = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Livrari__3213E83F7E257F4F", x => x.id);
                    table.ForeignKey(
                        name: "FK__Livrari__id_coma__36B12243",
                        column: x => x.id_comanda,
                        principalTable: "Comanda",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_id_hrana",
                table: "Abonament",
                column: "id_hrana");

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_id_utilizator",
                table: "Abonament",
                column: "id_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_id_abonament",
                table: "Comanda",
                column: "id_abonament");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_id_utilizator",
                table: "Comanda",
                column: "id_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Livrari_id_comanda",
                table: "Livrari",
                column: "id_comanda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "Animale");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Livrari");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Abonament");

            migrationBuilder.DropTable(
                name: "Hrana");

            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
