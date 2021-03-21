using Microsoft.Extensions.DependencyInjection;
using MyBank.Domain.Interfaces;
using MyBank.Infra.Data.Repository;

namespace MyBank.Infra.CrossCutting.InversionOfControl
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryConta, ContaRepository>();
            services.AddTransient<IRepositoryCliente, ClienteRepository>();
        }
    }
}
