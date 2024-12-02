using Fluxo.Core.Lancamentos.Commands;
using Fluxo.Core.Lancamentos.Repositories;
using Fluxo.Core.Lancamentos.Validators;
using Fluxo.SharedKernel.Lancamentos;
using MediatR;

namespace Fluxo.Core.Lancamentos.Handlers
{
    public class LancamentoCreateCmdHandler : IRequestHandler<LancamentoCreateCmd, Guid>
    {
        private readonly IMediator mediator;
        private readonly LancamentoCreateCmdValidator _validator;
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoCreateCmdHandler(IMediator mediator, LancamentoCreateCmdValidator validator, ILancamentoRepository lancamentoRepository)
        {
            this.mediator = mediator;
            _validator = validator;
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Guid> Handle(LancamentoCreateCmd request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                throw new InvalidOperationException(string.Join("\n", validation.Errors));

            var entity = new Lancamento
            {
                Id = Guid.NewGuid(),
                DataMovimentacao = request.DataMovimentacao,
                Historico = request.Historico,
                TipoLancamentoId = request.TipoLancamentoId,
                Valor = request.Valor,
                FormaPagamentoId = request.FormaPagamentoId,
            };

            await _lancamentoRepository.Add(entity);
            await _lancamentoRepository.Commit();

            await mediator.Publish(new LancamentoCreatedMessage
            {
                LancamentoId = entity.Id,
                //DataMovimentacao = entity.DataMovimentacao,
                //FormaPagamento = entity.FormaPagamento?.Descricao,
                //GrupoConsolidacao = entity.TipoLancamento.Grupo,
                //LancamentoId = entity.Id,
                //TipoLancamento = entity.TipoLancamento.Descricao,
                //TipoOperacao = (int)entity.TipoLancamento.TipoOperacaoPadrao,
                //Valor = entity.Valor,
            });

            return entity.Id;
        }
    }
}
