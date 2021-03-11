using Microsoft.Extensions.DependencyInjection;
using MyBank.Domain.Interfaces;
using MyBank.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependecy
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceCliente, ClienteService>();
            services.AddScoped<IServiceConta, ContaService>();
            services.AddScoped<IServiceContaCorrente, ContaCorrenteService>();
            services.AddScoped<IServiceContaPoupanca, ContaPoupancaService>();
        }
    }
}
