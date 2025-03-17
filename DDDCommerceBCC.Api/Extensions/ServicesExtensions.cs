using DDDCommerceBCC.Application.Services;
using DDDCommerceBCC.Application.Interfaces;
using DDDCommerceBCC.Infra.Interfaces;
using DDDCommerceBCC.Infra.Repositories;

namespace DDDCommerceBCC.Api.Extensions
{
    internal static class ServicesExtensions
    {
        internal static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}
