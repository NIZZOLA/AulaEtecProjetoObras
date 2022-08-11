using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obra.Infra.Migrations
{
    public partial class alteraçãodecontas : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoDePagamentoId",
                table: "ContaModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoDeDespesaReceitaId",
                table: "ContaModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpreendimentoId",
                table: "ContaModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoDePagamentoId",
                table: "ContaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoDeDespesaReceitaId",
                table: "ContaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpreendimentoId",
                table: "ContaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaModel_EmpreendimentoModel_EmpreendimentoId",
                table: "ContaModel",
                column: "EmpreendimentoId",
                principalTable: "EmpreendimentoModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId",
                table: "ContaModel",
                column: "TipoDeDespesaReceitaId",
                principalTable: "TipoDeDespesaReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaModel_TipoDePagamento_TipoDePagamentoId",
                table: "ContaModel",
                column: "TipoDePagamentoId",
                principalTable: "TipoDePagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
