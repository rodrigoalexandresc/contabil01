using Fluxo.Core.Lancamentos;
using Fluxo.Core.Lancamentos.Repositories;

namespace Fluxo.Data.Lancamentos
{
    public class LancamentoRepository : AbstractRepository, ILancamentoRepository
    {
        public LancamentoRepository(FluxoDbContext dbContext) : base(dbContext) { }

        public async Task Add(Lancamento entity) => _dbContext.Add(entity);

        public IQueryable<Lancamento> GetAll() => _dbContext.Set<Lancamento>().AsQueryable();
    }
}
