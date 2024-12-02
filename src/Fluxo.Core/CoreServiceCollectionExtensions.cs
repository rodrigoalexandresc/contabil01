using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Fluxo.Core.Lancamentos.Repositories;

namespace Fluxo.Core
{
    public static class CoreServiceCollectionExtensions
    {
        public static void AddFluxoCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
            
    }
}
