using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopDMZ.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCategoria",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategoria", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "TBFornecedor",
                columns: table => new
                {
                    IDFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFornecedor", x => x.IDFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "TBProduto",
                columns: table => new
                {
                    IDProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TBCategoriaIDCategoria = table.Column<int>(type: "int", nullable: true),
                    TBFornecedorIDFornecedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProduto", x => x.IDProduto);
                    table.ForeignKey(
                        name: "FK_TBProduto_TBCategoria_TBCategoriaIDCategoria",
                        column: x => x.TBCategoriaIDCategoria,
                        principalTable: "TBCategoria",
                        principalColumn: "IDCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBProduto_TBFornecedor_TBFornecedorIDFornecedor",
                        column: x => x.TBFornecedorIDFornecedor,
                        principalTable: "TBFornecedor",
                        principalColumn: "IDFornecedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBProduto_TBCategoriaIDCategoria",
                table: "TBProduto",
                column: "TBCategoriaIDCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_TBProduto_TBFornecedorIDFornecedor",
                table: "TBProduto",
                column: "TBFornecedorIDFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBProduto");

            migrationBuilder.DropTable(
                name: "TBCategoria");

            migrationBuilder.DropTable(
                name: "TBFornecedor");
        }
    }
}
