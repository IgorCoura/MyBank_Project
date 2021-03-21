using MyBank.Domain.Models;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public ReturnContaModel insert(CreateContaModel createConta);
        public IEnumerable<ReturnContaModel> Recover();
        public ReturnContaModel Recover(int id);
        public void Depositar(ConsultaContaModel contaModel);
        public void Sacar(ConsultaContaModel contaModel);
        public void Transferir(ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny);
    }
}
