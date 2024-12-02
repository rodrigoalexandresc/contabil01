using Fluxo.Core.Shared;

namespace Fluxo.Core.Lancamentos.Repositories
{
    public interface ILancamentoRepository : IRepository
    {
        Task Add(Lancamento entity);
        IQueryable<Lancamento> GetAll();
    }
}
