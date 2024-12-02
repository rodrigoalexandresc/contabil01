using Fluxo.Core.Lancamentos;
using Fluxo.Core.Pagamentos;
using Microsoft.EntityFrameworkCore;

namespace Fluxo.Data
{
    public class FluxoDbContext : DbContext
    {
        public FluxoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<TipoLancamento> TiposLancamento { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
    }
}
