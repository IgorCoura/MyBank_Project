using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public ReturnContaModel insert(CreateContaModel createConta);
        public IEnumerable<ReturnContaModel> Recover();
        public ReturnContaModel Login(int clienteId, string senha);
        public ReturnContaModel Recover(ConsultaContaModel contaModel);
        public void Depositar(ConsultaContaModel contaModel);
        public void Sacar(ConsultaContaModel contaModel);
        public void Transferir(ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny);
    }
}
