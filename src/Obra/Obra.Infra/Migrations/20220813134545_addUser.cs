using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obra.Infra.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaModel_EmpreendimentoModel_EmpreendimentoId",
                table: "ContaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId",
                table: "ContaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ContaModel_TipoDePagamento_TipoDePagamentoId",
                table: "ContaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                table: "EmpreendimentoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FotoEmpreendimentoModel_EmpreendimentoModel_EmpreendimentoId",
                table: "FotoEmpreendimentoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotoEmpreendimentoModel",
                table: "FotoEmpreendimentoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpreendimentoModel",
                table: "EmpreendimentoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaModel",
                table: "ContaModel");

            migrationBuilder.RenameTable(
                name: "FotoEmpreendimentoModel",
                newName: "FotosEmpreendimentos");

            migrationBuilder.RenameTable(
                name: "EmpreendimentoModel",
                newName: "Empreendimentos");

            migrationBuilder.RenameTable(
                name: "ContaModel",
                newName: "Contas");

            migrationBuilder.RenameIndex(
                name: "IX_FotoEmpreendimentoModel_EmpreendimentoId",
                table: "FotosEmpreendimentos",
                newName: "IX_FotosEmpreendimentos_EmpreendimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_EmpreendimentoModel_ClienteId",
                table: "Empreendimentos",
                newName: "IX_Empreendimentos_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ContaModel_TipoDePagamentoId",
                table: "Contas",
                newName: "IX_Contas_TipoDePagamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContaModel_TipoDeDespesaReceitaId",
                table: "Contas",
                newName: "IX_Contas_TipoDeDespesaReceitaId");

            migrationBuilder.RenameIndex(
                name: "IX_ContaModel_EmpreendimentoId",
                table: "Contas",
                newName: "IX_Contas_EmpreendimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotosEmpreendimentos",
                table: "FotosEmpreendimentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empreendimentos",
                table: "Empreendimentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Username);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Empreendimentos_EmpreendimentoId",
                table: "Contas",
                column: "EmpreendimentoId",
                principalTable: "Empreendimentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_TipoDeDespesaReceita_TipoDeDespesaReceitaId",
                table: "Contas",
                column: "TipoDeDespesaReceitaId",
                principalTable: "TipoDeDespesaReceita",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_TipoDePagamento_TipoDePagamentoId",
                table: "Contas",
                column: "TipoDePagamentoId",
                principalTable: "TipoDePagamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empreendimentos_ClienteFornecedor_ClienteId",
                table: "Empreendimentos",
                column: "ClienteId",
                principalTable: "ClienteFornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FotosEmpreendimentos_Empreendimentos_EmpreendimentoId",
                table: "FotosEmpreendimentos",
                column: "EmpreendimentoId",
                principalTable: "Empreendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Empreendimentos_EmpreendimentoId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_TipoDeDespesaReceita_TipoDeDespesaReceitaId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_TipoDePagamento_TipoDePagamentoId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empreendimentos_ClienteFornecedor_ClienteId",
                table: "Empreendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_FotosEmpreendimentos_Empreendimentos_EmpreendimentoId",
                table: "FotosEmpreendimentos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotosEmpreendimentos",
                table: "FotosEmpreendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empreendimentos",
                table: "Empreendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.RenameTable(
                name: "FotosEmpreendimentos",
                newName: "FotoEmpreendimentoModel");

            migrationBuilder.RenameTable(
                name: "Empreendimentos",
                newName: "EmpreendimentoModel");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "ContaModel");

            migrationBuilder.RenameIndex(
                name: "IX_FotosEmpreendimentos_EmpreendimentoId",
                table: "FotoEmpreendimentoModel",
                newName: "IX_FotoEmpreendimentoModel_EmpreendimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Empreendimentos_ClienteId",
                table: "EmpreendimentoModel",
                newName: "IX_EmpreendimentoModel_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_TipoDePagamentoId",
                table: "ContaModel",
                newName: "IX_ContaModel_TipoDePagamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_TipoDeDespesaReceitaId",
                table: "ContaModel",
                newName: "IX_ContaModel_TipoDeDespesaReceitaId");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_EmpreendimentoId",
                table: "ContaModel",
                newName: "IX_ContaModel_EmpreendimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotoEmpreendimentoModel",
                table: "FotoEmpreendimentoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpreendimentoModel",
                table: "EmpreendimentoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaModel",
                table: "ContaModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaModel_EmpreendimentoModel_EmpreendimentoId",
                table: "ContaModel",
                column: "EmpreendimentoId",
                principalTable: "EmpreendimentoModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId",
                table: "ContaModel",
                column: "TipoDeDespesaReceitaId",
                principalTable: "TipoDeDespesaReceita",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaModel_TipoDePagamento_TipoDePagamentoId",
                table: "ContaModel",
                column: "TipoDePagamentoId",
                principalTable: "TipoDePagamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                table: "EmpreendimentoModel",
                column: "ClienteId",
                principalTable: "ClienteFornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FotoEmpreendimentoModel_EmpreendimentoModel_EmpreendimentoId",
                table: "FotoEmpreendimentoModel",
                column: "EmpreendimentoId",
                principalTable: "EmpreendimentoModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
