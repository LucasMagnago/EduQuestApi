using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNaConquista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Custo",
                table: "Itens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagemBase64",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "XpDesbloqueio",
                table: "Itens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "Custo", "Descricao", "ImagemBase64", "Nome", "Tipo", "XpDesbloqueio" },
                values: new object[,]
                {
                    { 1, 300, "Avatar estilizado com roupa ninja azul.", "", "Avatar Ninja Azul", 1, 1000 },
                    { 2, 300, "Avatar com aparência metálica e olhos brilhantes.", "", "Avatar Robô Futurista", 1, 1000 },
                    { 3, 300, "Moldura elegante dourada ao redor da imagem de perfil.", "", "Borda Dourada para Perfil", 2, 1000 },
                    { 4, 300, "Moldura azulada com efeito de cristal.", "", "Borda de Cristal Azul", 2, 1000 },
                    { 5, 300, "Altera a interface da plataforma para tons escuros.", "", "Tema Noturno", 3, 2000 },
                    { 6, 300, "Transforma o ambiente da plataforma em uma floresta mágica.", "", "Tema Floresta Encantada", 3, 3000 },
                    { 7, 300, "Interface com neon e circuitos inspirada no futuro.", "", "Tema Cibernético", 3, 4000 },
                    { 8, 300, "Visual marinho com tons de azul e bolhas.", "", "Tema Oceano Profundo", 3, 5000 }
                });

            migrationBuilder.InsertData(
                table: "AlunoPossuiItens",
                columns: new[] { "Id", "AlunoId", "DataAquisicao", "ItemId" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 5, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 5, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 5, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 6, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AlunoPossuiItens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AlunoPossuiItens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AlunoPossuiItens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AlunoPossuiItens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AlunoPossuiItens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Custo",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "ImagemBase64",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "XpDesbloqueio",
                table: "Itens");
        }
    }
}
