using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obra.Infra.Migrations
{
    public partial class descricaodafoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                table: "EmpreendimentoModel");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "FotoEmpreendimentoModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "EmpreendimentoModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                table: "EmpreendimentoModel",
                column: "ClienteId",
                principalTable: "ClienteFornecedor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                table: "EmpreendimentoModel");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "FotoEmpreendimentoModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "EmpreendimentoModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpreendimentoModel_ClienteFornecedor_ClienteId",
                table: "EmpreendimentoModel",
                column: "ClienteId",
                principalTable: "ClienteFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
