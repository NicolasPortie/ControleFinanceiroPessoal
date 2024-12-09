using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiroPessoal.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaInvestimento",
                columns: table => new
                {
                    IdCategoriaInvestimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeInvestimento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoCategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxaJuros = table.Column<bool>(type: "bit", nullable: false),
                    JurosAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaInvestimento", x => x.IdCategoriaInvestimento);
                });

            migrationBuilder.CreateTable(
                name: "ContasFinanceiras",
                columns: table => new
                {
                    IdContaFinanceira = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoConta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeInstituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasFinanceiras", x => x.IdContaFinanceira);
                });

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    IdInvestimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoriaInvestimento = table.Column<int>(type: "int", nullable: false),
                    ValorInvestido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInvestimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorFuturo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.IdInvestimento);
                    table.ForeignKey(
                        name: "FK_Investimentos_CategoriaInvestimento_IdCategoriaInvestimento",
                        column: x => x.IdCategoriaInvestimento,
                        principalTable: "CategoriaInvestimento",
                        principalColumn: "IdCategoriaInvestimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    IdDespesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContaFinanceira = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagamentoRealizado = table.Column<bool>(type: "bit", nullable: false),
                    Recorrente = table.Column<bool>(type: "bit", nullable: false),
                    Intervalo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroParcelas = table.Column<int>(type: "int", nullable: false),
                    ParcelasRestantes = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.IdDespesa);
                    table.ForeignKey(
                        name: "FK_Despesas_ContasFinanceiras_IdContaFinanceira",
                        column: x => x.IdContaFinanceira,
                        principalTable: "ContasFinanceiras",
                        principalColumn: "IdContaFinanceira",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    IdReceita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdContaFinanceira = table.Column<int>(type: "int", nullable: false),
                    FormaRecebimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recorrente = table.Column<bool>(type: "bit", nullable: false),
                    Intervalo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFinalRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.IdReceita);
                    table.ForeignKey(
                        name: "FK_Receitas_ContasFinanceiras_IdContaFinanceira",
                        column: x => x.IdContaFinanceira,
                        principalTable: "ContasFinanceiras",
                        principalColumn: "IdContaFinanceira",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_IdContaFinanceira",
                table: "Despesas",
                column: "IdContaFinanceira");

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_IdCategoriaInvestimento",
                table: "Investimentos",
                column: "IdCategoriaInvestimento");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_IdContaFinanceira",
                table: "Receitas",
                column: "IdContaFinanceira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "CategoriaInvestimento");

            migrationBuilder.DropTable(
                name: "ContasFinanceiras");
        }
    }
}
