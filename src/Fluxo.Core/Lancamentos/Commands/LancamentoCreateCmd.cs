using MediatR;

namespace Fluxo.Core.Lancamentos.Commands
{
    public record LancamentoCreateCmd : IRequest<Guid>
    {
        public DateTime DataMovimentacao { get; set; }
        public int TipoLancamentoId { get; set; }
        public decimal Valor { get; set; }
        public string Historico { get; set; } = string.Empty;
        public int? FormaPagamentoId { get; set; }
    }
}
