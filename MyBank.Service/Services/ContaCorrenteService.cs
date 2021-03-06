using MyBank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Service.Services
{
    public class ContaCorrenteService: ContaService, IServiceContaCorrente
    {
        public ContaCorrenteService(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
        }
    }
}
