using Fluxo.Consolidacao.Core.Lancamentos;
using Fluxo.SharedKernel.Lancamentos;

namespace Fluxo.Consolidacao.Service.Lancamentos
{
    public class ConsolidacaoService
    {
        private readonly ILancamentoResumidoRepository _lancamentoRepository;

        public ConsolidacaoService(ILancamentoResumidoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task Consolidar(LancamentoCreatedMessage lancamentoCreatedEvent)
        {
            // _lancamentoRepository.Add(new)
        }
    }
}
