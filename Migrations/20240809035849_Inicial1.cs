using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Libros",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Libros",
                newName: "Descripcion");

            migrationBuilder.AddColumn<bool>(
                name: "EsActivo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EsActivo",
                table: "Prestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDevolucion",
                table: "Prestamos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaNavigationIdCategoria",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NumeroDocumentos",
                columns: table => new
                {
                    IdNumeroDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoNumero = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroDocumentos", x => x.IdNumeroDocumento);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdCategoriaNavigationIdCategoria",
                table: "Libros",
                column: "IdCategoriaNavigationIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_IdCategoriaNavigationIdCategoria",
                table: "Libros",
                column: "IdCategoriaNavigationIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_IdCategoriaNavigationIdCategoria",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "NumeroDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_Libros_IdCategoriaNavigationIdCategoria",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "EsActivo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EsActivo",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "FechaDevolucion",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "IdCategoriaNavigationIdCategoria",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Libros",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Libros",
                newName: "Description");
        }
    }
}
