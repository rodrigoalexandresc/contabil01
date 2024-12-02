using Contabil.Shared;

namespace Fluxo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly FluxoDbContext _context;

        public UnitOfWork(FluxoDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
