using Fluxo.Core.Lancamentos.Dtos;
using Fluxo.Core.Lancamentos.Queries;
using Fluxo.Core.Lancamentos.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Fluxo.Core.Lancamentos.Handlers
{
    public class LancamentoQueryHandler : IRequestHandler<LancamentoQuery, IEnumerable<LancamentoDto>>
    {
        private readonly ILancamentoRepository _repository;

        public LancamentoQueryHandler(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LancamentoDto>> Handle(LancamentoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll()
                .Where(o => o.DataMovimentacao >= request.DataInicial)
                .Where(o => o.DataMovimentacao <= request.DataFinal)
                .Select(o => new LancamentoDto
                {
                    Data = o.DataMovimentacao,
                    Historico = o.Historico,
                    Id = o.Id,
                    Tipo = o.TipoLancamento.Descricao,
                    Valor = o.Valor
                })
                .ToListAsync();


        }
    }
}
