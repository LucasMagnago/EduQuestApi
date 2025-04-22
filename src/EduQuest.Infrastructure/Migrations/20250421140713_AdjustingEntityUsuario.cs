using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustingEntityUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "SenhaHash");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "UsuarioEscolaPerfis",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "UsuarioEscolaPerfis");

            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Usuarios",
                newName: "Senha");
        }
    }
}
