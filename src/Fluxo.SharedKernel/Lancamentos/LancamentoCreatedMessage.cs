using MediatR;

namespace Fluxo.SharedKernel.Lancamentos
{
    public record LancamentoCreatedMessage : INotification
    {
        public Guid LancamentoId { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public decimal Valor { get; set; }
        public int TipoOperacao { get; set; }
        public string TipoLancamento { get; set; }
        public string GrupoConsolidacao { get; set; }
        public string? FormaPagamento { get; set; }

    }
}
