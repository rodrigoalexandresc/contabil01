using Fluxo.Core.Lancamentos.Commands;
using Fluxo.Core.Lancamentos.Mappers;
using Fluxo.Core.Lancamentos.Repositories;
using Fluxo.SharedKernel.Bus;
using Fluxo.SharedKernel.Lancamentos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Fluxo.Core.Lancamentos.Handlers
{
    public class LancamentoReenvioCmdHandler : IRequestHandler<LancamentoReenvioCmd>
    {
        IMessageSender _messageSender;
        ILancamentoRepository _lancamentoRepository;

        public LancamentoReenvioCmdHandler(IMessageSender messageSender, ILancamentoRepository lancamentoRepository)
        {
            _messageSender = messageSender;
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task Handle(LancamentoReenvioCmd request, CancellationToken cancellationToken)
        {
            var lancamentos = await _lancamentoRepository.GetAll().Select(o => new LancamentoCreatedMessage
            {
                LancamentoId = o.Id,
                DataMovimentacao = o.DataMovimentacao,
                FormaPagamento = o.FormaPagamento != null ? o.FormaPagamento.Descricao : string.Empty,
                GrupoConsolidacao = o.TipoLancamento.Grupo,
                TipoLancamento = o.TipoLancamento.Descricao,
                TipoOperacao = (int)o.TipoLancamento.TipoOperacaoPadrao,
                Valor = o.Valor,
            }).ToListAsync();

            foreach (var lancamento in lancamentos)
            {
                await _messageSender.Send(TopicConsts.LancamentoFluxo, lancamento);
            }
        }
    }
}
