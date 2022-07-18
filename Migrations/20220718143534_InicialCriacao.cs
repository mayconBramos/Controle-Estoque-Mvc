using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_Estoque_Mvc.Migrations
{
    public partial class InicialCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrada-Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeMarca = table.Column<string>(name: "Nome/Marca", type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Recebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada-Estoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeMarca = table.Column<string>(name: "Nome/Marca", type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Recebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada-Estoque");

            migrationBuilder.DropTable(
                name: "Estoque");
        }
    }
}
