using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopDMZ.Migrations
{
    public partial class Inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBImagem",
                columns: table => new
                {
                    IDImagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    TBProdutoIDProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBImagem", x => x.IDImagem);
                    table.ForeignKey(
                        name: "FK_TBImagem_TBProduto_TBProdutoIDProduto",
                        column: x => x.TBProdutoIDProduto,
                        principalTable: "TBProduto",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBVendidos",
                columns: table => new
                {
                    IDV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVendidos", x => x.IDV);
                });

            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TBVendidosIDV = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.IDCliente);
                    table.ForeignKey(
                        name: "FK_TBCliente_TBVendidos_TBVendidosIDV",
                        column: x => x.TBVendidosIDV,
                        principalTable: "TBVendidos",
                        principalColumn: "IDV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBProdutoTBVendidos",
                columns: table => new
                {
                    TBProdutoIDProduto = table.Column<int>(type: "int", nullable: false),
                    TBVendidosIDV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProdutoTBVendidos", x => new { x.TBProdutoIDProduto, x.TBVendidosIDV });
                    table.ForeignKey(
                        name: "FK_TBProdutoTBVendidos_TBProduto_TBProdutoIDProduto",
                        column: x => x.TBProdutoIDProduto,
                        principalTable: "TBProduto",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBProdutoTBVendidos_TBVendidos_TBVendidosIDV",
                        column: x => x.TBVendidosIDV,
                        principalTable: "TBVendidos",
                        principalColumn: "IDV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_TBVendidosIDV",
                table: "TBCliente",
                column: "TBVendidosIDV");

            migrationBuilder.CreateIndex(
                name: "IX_TBImagem_TBProdutoIDProduto",
                table: "TBImagem",
                column: "TBProdutoIDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_TBProdutoTBVendidos_TBVendidosIDV",
                table: "TBProdutoTBVendidos",
                column: "TBVendidosIDV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBImagem");

            migrationBuilder.DropTable(
                name: "TBProdutoTBVendidos");

            migrationBuilder.DropTable(
                name: "TBVendidos");
        }
    }
}
