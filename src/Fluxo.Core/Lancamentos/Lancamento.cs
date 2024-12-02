using Fluxo.Core.Pagamentos;

namespace Fluxo.Core.Lancamentos
{
    public class Lancamento
    {
        public Guid Id { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public int TipoLancamentoId { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public decimal Valor { get; set; }
        public string Historico { get; set; } = string.Empty;
        public int? FormaPagamentoId { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
        
    }
}
