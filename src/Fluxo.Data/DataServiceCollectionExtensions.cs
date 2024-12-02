using Fluxo.Core.Lancamentos.Repositories;
using Fluxo.Data.Lancamentos;
using Microsoft.Extensions.DependencyInjection;

namespace Fluxo.Core
{
    public static class DataServiceCollectionExtensions
    {
        public static void AddFluxoDataServices(this IServiceCollection services)
        {
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
        }
            
    }
}
