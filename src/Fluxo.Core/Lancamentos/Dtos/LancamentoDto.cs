using Fluxo.SharedKernel.Lancamentos;

namespace Fluxo.Core.Lancamentos.Dtos
{
    public record LancamentoDto
    {
        public Guid Id { get; set; }
        public string Historico { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
