using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fluxo.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposLancamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    HistoricoPadrao = table.Column<string>(type: "text", nullable: false),
                    TipoOperacaoPadrao = table.Column<int>(type: "integer", nullable: false),
                    Grupo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposLancamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TipoLancamentoId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_FormasPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormasPagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lancamentos_TiposLancamento_TipoLancamentoId",
                        column: x => x.TipoLancamentoId,
                        principalTable: "TiposLancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_FormaPagamentoId",
                table: "Lancamentos",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_TipoLancamentoId",
                table: "Lancamentos",
                column: "TipoLancamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "TiposLancamento");
        }
    }
}
