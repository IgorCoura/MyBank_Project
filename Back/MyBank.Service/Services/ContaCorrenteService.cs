using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Service.Services
{
    public class ContaCorrenteService: ContaService, IServiceContaCorrente
    {
        private readonly IRepositoryContaCorrente _repositoryConta;
        public ContaCorrenteService(IRepositoryContaCorrente repositoryConta, IServiceCliente serviceCliente) : base(repositoryConta, serviceCliente)
        {
            _repositoryConta = repositoryConta;
        }

        public override void Sacar(ConsultaContaModel contaModel)
        {
        }
    }
}
