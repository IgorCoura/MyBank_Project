using MyBank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Service.Services
{
    public class ContaPoupancaService : ContaService, IServiceContaPoupanca
    {
        public ContaPoupancaService(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
        }
    }
}
