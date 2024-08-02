using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Criacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoPesquisa",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PROFESSOR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CARGA_HORARIA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    DATA_PESQUISA = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoPesquisa", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoPesquisa");
        }
    }
}
