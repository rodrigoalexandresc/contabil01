using Fluxo.Core.Lancamentos.Dtos;
using Fluxo.SharedKernel.Lancamentos;
using MediatR;

namespace Fluxo.Core.Lancamentos.Queries
{
    public record LancamentoQuery : IRequest<IEnumerable<LancamentoDto>>
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
