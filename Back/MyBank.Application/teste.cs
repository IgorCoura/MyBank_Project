using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Application.Api
{
    public class teste
    {
        IServiceCliente serviceCliente;
        IServiceConta serviceConta;

        public teste(IServiceCliente serviceCliente, IServiceConta serviceConta)
        {
            this.serviceCliente = serviceCliente;
            this.serviceConta = serviceConta;
        }

        public void createContas()
        {           
            var cliente  = new CreateClienteModel("admin", "825.175.800-90", "20/20/20");
            serviceCliente.Insert(cliente);
            var conta = new CreateContaModel("825.175.800-90", 999, 999, "admin");
            serviceConta.insert(conta);
        }
    }
}
