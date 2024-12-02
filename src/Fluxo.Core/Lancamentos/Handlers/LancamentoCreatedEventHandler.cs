using Fluxo.Core.Lancamentos.Mappers;
using Fluxo.Core.Lancamentos.Repositories;
using Fluxo.SharedKernel.Bus;
using Fluxo.SharedKernel.Lancamentos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Fluxo.Core.Lancamentos.Handlers
{
    public class LancamentoCreatedEventHandler : INotificationHandler<LancamentoCreatedMessage>
    {
        private readonly IMessageSender _messageSender;
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoCreatedEventHandler(IMessageSender messageSender, ILancamentoRepository lancamentoRepository)
        {
            _messageSender = messageSender;
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task Handle(LancamentoCreatedMessage notification, CancellationToken cancellationToken)
        {
            var lancamento = await _lancamentoRepository.GetAll()
                .Where(o => o.Id == notification.LancamentoId)
                .Select(o => o.MapToLancamentoCreatedMessage())
                .FirstOrDefaultAsync();

            await _messageSender.Send(TopicConsts.LancamentoFluxo, notification);
        }
    }
}
