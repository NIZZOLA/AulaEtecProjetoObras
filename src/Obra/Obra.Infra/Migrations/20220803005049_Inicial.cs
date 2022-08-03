using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obra.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cliente = table.Column<bool>(type: "bit", nullable: false),
                    Fornecedor = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    OptanteDoSimples = table.Column<bool>(type: "bit", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdExclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeDespesaReceita",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Receita = table.Column<bool>(type: "bit", nullable: false),
                    Despesa = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdExclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeDespesaReceita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDePagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdExclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDePagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpreendimentoModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataOrcamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevistaTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdExclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpreendimentoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpreendimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDoPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDaCompra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroDoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeDespesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoDeDespesaReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDePagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdExclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaModel_EmpreendimentoModel_EmpreendimentoId",
                        column: x => x.EmpreendimentoId,
                        principalTable: "EmpreendimentoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId",
                        column: x => x.TipoDeDespesaReceitaId,
                        principalTable: "TipoDeDespesaReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaModel_TipoDePagamento_TipoDePagamentoId",
                        column: x => x.TipoDePagamentoId,
                        principalTable: "TipoDePagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotoEmpreendimentoModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpreendimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdExclusao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoEmpreendimentoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoEmpreendimentoModel_EmpreendimentoModel_EmpreendimentoId",
                        column: x => x.EmpreendimentoId,
                        principalTable: "EmpreendimentoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaModel_EmpreendimentoId",
                table: "ContaModel",
                column: "EmpreendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContaModel_TipoDeDespesaReceitaId",
                table: "ContaModel",
                column: "TipoDeDespesaReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContaModel_TipoDePagamentoId",
                table: "ContaModel",
                column: "TipoDePagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpreendimentoModel_ClienteId",
                table: "EmpreendimentoModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FotoEmpreendimentoModel_EmpreendimentoId",
                table: "FotoEmpreendimentoModel",
                column: "EmpreendimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaModel");

            migrationBuilder.DropTable(
                name: "FotoEmpreendimentoModel");

            migrationBuilder.DropTable(
                name: "TipoDeDespesaReceita");

            migrationBuilder.DropTable(
                name: "TipoDePagamento");

            migrationBuilder.DropTable(
                name: "EmpreendimentoModel");

            migrationBuilder.DropTable(
                name: "ClienteFornecedor");
        }
    }
}
