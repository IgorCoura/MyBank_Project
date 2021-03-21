using Microsoft.Extensions.DependencyInjection;
using MyBank.Domain.Interfaces;
using MyBank.Service.Services;

namespace MyBank.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependecy
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddTransient<IServiceCliente, ClienteService>();
            services.AddTransient<IServiceConta, ContaService>();
        }
    }
}
