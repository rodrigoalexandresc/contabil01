using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fluxo.Data.Migrations
{
    /// <inheritdoc />
    public partial class TipoLancamentoPadrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ""TiposLancamento"" (""Id"", ""Descricao"", ""HistoricoPadrao"", ""TipoOperacaoPadrao"", ""Grupo"")
                values 
                (1, 'VENDA MERCADORIA', 'VENDA MERCADORIA', 1, 'ATIVIDADES OPERACIONAIS'),
                (2, 'PAGAMENTO FORNECEDOR', 'PGTO FOR: [fornecedor]', 2, 'ATIVIDADES OPERACIONAIS'),
                (3, 'VENDA GOV', 'VENDA MERCADORIA DIRETA', 1, 'ATIVIDADES OPERACIONAIS'),
                (4, 'VENDA PJ', 'VENDA PJ', 1, 'ATIVIDADES OPERACIONAIS'),
                (5, 'PAGAMENTO TRIBUTOS', 'PGTO TRIBUTO: ', 2, 'ATIVIDADES FISCAIS'),
                (6, 'RECEBIMENTO JUROS', 'CONTRATO:', 1, 'ATIVIDADES FINANCIAMENTO'),
                (7, 'AMORTIZAÇÃO DE DÍVIDA', 'CONTRATO:', 2, 'ATIVIDADES FINANCIAMENTO'),
                (8, 'RECUPERAÇÀO DE TRIBUTOS', 'TRIBUTO: ', 1, 'ATIVIDADES FISCAIS')
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
