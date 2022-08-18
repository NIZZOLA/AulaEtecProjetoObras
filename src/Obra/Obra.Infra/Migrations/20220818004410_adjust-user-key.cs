using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obra.Infra.Migrations
{
    public partial class adjustuserkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioIdAlteracao",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioIdCriacao",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioIdExclusao",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioIdAlteracao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioIdCriacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioIdExclusao",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Username");
        }
    }
}
