using Microsoft.Extensions.DependencyInjection;
using MyBank.Domain.Interfaces;
using MyBank.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.CrossCutting.InversionOfControl
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddSingleton<IRepositoryConta, ContaRepository>();
            services.AddSingleton<IRepositoryCliente, ClienteRepository>();
        }
    }
}
